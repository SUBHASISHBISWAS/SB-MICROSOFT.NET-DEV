/* MainWindow.xaml.cs */

//
// Sequential Search Version (big file support)
//
//   Given a set of log files and a regular expression, searches the files and outputs the
// total number of search hits.  Tasks are used in an async way to keep the UI responsive 
// while the search is carried out; the search itself, however, is done sequentially in
// this version.  This version supports files of any size by reading in blocks of size
// 1MB; it handles matches that may cross block boundaries by using a "window" of size
// 1K --- the last 1K of the current block is carried over and placed at the start of
// the next block, and the matching restarted.  Not perfect, but good in most cases (will
// fail to detect the hit if the match length is > the window size).    
//
//   By default, the demo is setup to search for IP addresses of the form 202.187.*.*.  The
// idea is to search the log files for IP ranges of known hacker machines.
//
// NOTE: the log files are assumed to be just text files, no particular format is assumed
// during the search.  To generate log files for performance testing, see the accompanying
// program "datafiles\GenRandomLogFiles".
//

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;

// create an alias for tuple-based result:
using SearchResult = System.Tuple<int, long, long, long>;


namespace SearchLogFiles
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}


		/// <summary>
		/// Triggered when form is first loaded into memory; init here.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.txtPattern.Focus();
			this.txtPattern.SelectAll();

			//
			// add default logfiles in the listbox for demo purposes:
			//
			string initialdir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "logfiles");

			if (Directory.Exists(initialdir))
			{
				string[] FNs = System.IO.Directory.GetFiles(initialdir);

				foreach (string fullFN in FNs)
					this.lstFiles.Items.Add(new DisplayFileName(System.IO.Path.GetFileName(fullFN), fullFN));
			}
		}


		/// <summary>
		/// User is selecting files to search...
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SelectLogFiles_Click(object sender, RoutedEventArgs e)
		{
			// 
			// Prep open file dialog to get filename(s) from user:
			//
			var dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.Filter = "*.*|*.*";
			dialog.Multiselect = true;

			string initialdir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "logfiles");
			if (Directory.Exists(initialdir))
				dialog.InitialDirectory = initialdir;

			// 
			// show --- did user select files and click OK?
			//
			bool? ok = dialog.ShowDialog();

			if (ok.HasValue && ok.Value == true)  // user selected one or more log files:
			{
				// so fill list box with filenames:
				this.lstFiles.Items.Clear();

				foreach (string fullFN in dialog.FileNames)
					this.lstFiles.Items.Add(new DisplayFileName(System.IO.Path.GetFileName(fullFN), fullFN));
			}
		}


		/// <summary>
		/// User has clicked button to search the log files based on the given pattern, so 
		/// let's up an set of tasks to run this in the background so we don't lock the UI.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdSearch_Click(object sender, RoutedEventArgs e)
		{
			this.txtblkResults.Text = "";      // clear previous results...

			this.cmdSearch.IsEnabled = false;  // disable button until we are done:
			this.spinnerWait.Visibility = System.Windows.Visibility.Visible;
			this.spinnerWait.Spin = true;

			var sw = new System.Diagnostics.Stopwatch();  // start clock:
			sw.Restart();

			//
			// search all the files listed in the listbox:
			//
			List<string> filenames = new List<string>();

			foreach (DisplayFileName dfn in this.lstFiles.Items)
				filenames.Add(dfn.FullFileName);

			string pattern = this.txtPattern.Text;

			// create a task to make the call so we don't lock up the UI:
			Task<SearchResult> search = Task.Factory.StartNew<SearchResult>(() =>
				{
					return SearchFiles(filenames, pattern);
				}
			);

			//
			// When the search task finishes, update the UI.  We another task to wait for the result 
			// so that we don't lock up the UI waiting --- but this has to be a separate task since
			// any UI work must be done by the thread that owns the UI (the main thread):
			//
			Task UpdateUI = search.ContinueWith((antecedent) =>
				{
					try
					{
						SearchResult result = antecedent.Result;

						int hits = result.Item1;
						long ioTimeinMS = result.Item2;
						long strTimeinMS = result.Item3;
						long srchTimeinMS = result.Item4;

						var timeinMS = sw.ElapsedMilliseconds;  // stop clock:
						double time = timeinMS / 1000.0;  // convert to secs:

						string results = string.Format("Hits:\t{0:#,##0}\nFiles:\t{1:#,##0}\nTime:\t{2:#,##0.00} secs\n",
							hits,
							lstFiles.Items.Count,
							time);

						this.txtblkResults.Text = results;

						this.txtblkResults.Text += string.Format("\n[ Time:\tI/O, ToStr, Search = ({0:0}%, {1:0}%, {2:0}%) ]\n",
							(ioTimeinMS / (double)timeinMS) * 100.0,
							(strTimeinMS / (double)timeinMS) * 100.0,
							(srchTimeinMS / (double)timeinMS) * 100.0);
					}
					catch (AggregateException ae)
					{
						this.txtblkResults.Text = "";

						ae = ae.Flatten();
						foreach (Exception ex in ae.InnerExceptions)
							this.txtblkResults.Text += string.Format("**Error: '{0}'\n", ex.Message);
					}
					catch (Exception ex)
					{
						this.txtblkResults.Text = string.Format("**Error: '{0}'\n", ex.Message);
					}

					// reset UI:
					this.spinnerWait.Spin = false;
					this.spinnerWait.Visibility = System.Windows.Visibility.Collapsed;

					this.cmdSearch.IsEnabled = true;  // re-enable button:
				},

				TaskScheduler.FromCurrentSynchronizationContext()  // must run on current (UI) thread:
			);
		}


		/// <summary>
		/// Does the actual work of searching the list of log files, returning the total number 
		/// of hits.
		/// </summary>
		/// <param name="filenames"></param>
		/// <param name="pattern"></param>
		/// <returns># of search hits, I/O time, String conversion time, Search time</returns>
		private SearchResult SearchFiles(List<string> filenames, string pattern)
		{
			// we apply same reg expr to each file, so create 1 compiled RE and reuse:
			Regex re = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Multiline);

			var sw = new System.Diagnostics.Stopwatch();
			long ioTime, strTime, srchTime;
			ioTime = strTime = srchTime = 0;

			//
			// To support large files, we read block-by-block instead of trying to read all 
			// at once.  To handle matches that may occur across block boundaries, we slide
			// a "window" from the end of one block to the start of the next.
			//
			int BLOCK_SIZE = 1048576;  // 1MB
			int WINDOW_SIZE = 1024;    // 1K

			System.Diagnostics.Debug.Assert(BLOCK_SIZE > WINDOW_SIZE);

			int BUFFER_SIZE = BLOCK_SIZE + WINDOW_SIZE;
			byte[] buf = new byte[BUFFER_SIZE];

			int windowOffset = 0;  // first block has no window beforehand:

			//
			// For each file f, search it:
			//
			int hits = 0;

			foreach (string f in filenames)
			{
				//
				// Create a filestream and read block by block:
				//
				using (FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read))
				{
					FileInfo fi = new FileInfo(f);
					long bytesLeft = fi.Length;

					while (bytesLeft > 0)
					{
						// read a chunk:
						sw.Restart();
						int bytesRead = fs.Read(buf, windowOffset, BLOCK_SIZE);
						ioTime += sw.ElapsedMilliseconds;

						int numBytesInBuf = windowOffset + bytesRead;

						// convert to string for processing:
						sw.Restart();
						string block = System.Text.Encoding.UTF8.GetString(buf, 0, numBytesInBuf);
						strTime += sw.ElapsedMilliseconds;

						// apply pattern repeatedly as a regular expression:
						sw.Restart();
						Match m = re.Match(block);

						int startOfNextSearch = -1;

						while (m.Success)  // repeat for each successive match:
						{
							hits++;
							startOfNextSearch = m.Index + m.Length;

							m = m.NextMatch();
						}

						// repeat for any bytes remaining in file:
						bytesLeft -= bytesRead;

						//
						// in case matches occur *across* a block, we copy a "window" worth of data from
						// the end of this block and place it at the beginning of the next block so we'll
						// catch any cross-block matches (assuming a large-enough window size, which 
						// perhaps the user should supply or at least be able override):
						//
						if (bytesLeft > 0)  // still data to process:
						{
							// then we read at least a BLOCK_SIZE, so following should be true:
							System.Diagnostics.Debug.Assert(numBytesInBuf > WINDOW_SIZE);

							int srcIndex = numBytesInBuf - WINDOW_SIZE;
							int bytesToCopy = WINDOW_SIZE;

							if (startOfNextSearch > srcIndex)  // if the last match was inside window, don't copy those bytes:
							{
								srcIndex = startOfNextSearch;
								bytesToCopy = numBytesInBuf - startOfNextSearch;
							}

							Array.Copy(buf, srcIndex, buf, 0, bytesToCopy);
							windowOffset = bytesToCopy;
						}

						srchTime += sw.ElapsedMilliseconds;
					}//while

				}//using
			}//foreach

			//
			// done, return <total # of search hits, io time, str time, search time>:
			//
			return new SearchResult(hits, ioTime, strTime, srchTime);
		}

	}//class
}//namespace