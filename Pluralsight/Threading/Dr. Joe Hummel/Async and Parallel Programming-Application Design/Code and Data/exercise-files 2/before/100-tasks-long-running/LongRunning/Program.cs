﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

//
// Creates 100 long-running tasks to see how .NET 4 responds.  In this case,
// we create 100 long-running tasks all at once, which causes .NET to create
// 100 non-worker pool threads --- and CPU to thrash due to over-subscription 
// and too many context switches.  Not to mention cost of creating these 100
// threads, and memory for their stack space...
//
// To run:  run without debugging (ctrl+F5), open task manager, view processes,
// and add "threads" column to the view.  Watch number of threads grow, slowly
// but surely.
//
namespace LongRunning
{
  class Program
  {

		public static void Main(string[] args)
		{
			int N = 100;
			int durationInMins = 5;
			int durationInSecs = 0;

			Welcome(N, durationInMins, durationInSecs);

			//
			// Create 100 long-running tasks all at once, and then wait for them 
			// to finish:
			//
			List<Task> tasks = new List<Task>();

			for (int i = 0; i < N; i++)
			{
				Task t = CreateOneLongRunningTask(durationInMins, durationInSecs,
					TaskCreationOptions.LongRunning);

				tasks.Add(t);
			}

			Task.WaitAll(tasks.ToArray());

			//
			// done:
			//
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("** Done!");
		}


		//
		// chews on CPU for give mins and secs:
		//
		static Task CreateOneLongRunningTask(int durationInMins, int durationInSecs, TaskCreationOptions options)
		{
			long durationInMilliSecs = durationInMins * 60 * 1000;
			durationInMilliSecs += (durationInSecs * 1000);

			Task t = Task.Factory.StartNew(() =>
				{
				  Console.WriteLine("starting task...");

					var sw = System.Diagnostics.Stopwatch.StartNew();
					long count = 0;

					while (sw.ElapsedMilliseconds < durationInMilliSecs)
					{
						count++;
						if (count == 1000000000)
							count = 0;
					}
					
				  Console.WriteLine("task finished.");
				}, 
				options
			);

			return t;
		}


		//
		// Welcome the user:
		//
		static void Welcome(int N, int durationInMins, int durationInSecs)
		{
			String version, platform;

#if DEBUG
			version = "debug";
#else
			version = "release";
#endif

#if _WIN64
	platform = "64-bit";
#elif _WIN32
	platform = "32-bit";
#else
			platform = "any-cpu";
#endif

			Console.WriteLine("** Long-running Tasks App -- Long-running tasks, all at once [{0}, {1}] **", platform, version);
			Console.WriteLine("   Number of tasks: {0:#,##0}", N);
			Console.WriteLine("   Number of cores: {0:#,##0}", System.Environment.ProcessorCount);
			Console.WriteLine("   Task duration:   {0:#,##0} mins, {1:#,##0} secs", durationInMins, durationInSecs);
			Console.WriteLine();
		}

   }//class
}//namespace
