using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

//
// Creates 100 long-running tasks to see how .NET 4 responds.  In this case,
// we create 100 standard tasks but set the MaxDegreeOfParallelism to the # 
// of cores reported by .NET.  This prevents .NET from trying to start all
// 100 tasks at the same time, which would over-subscribe the system.
//
// To run:  run without debugging (ctrl+F5), open task manager, view processes,
// and add "threads" column to the view.  Confirm that the # of threads shown
// does NOT grow, which is what we want.
//
namespace LongRunning
{
  class Program
  {

    public static void Main(string[] args)
    {
			int N = 100;
			int durationInMins = 0;
			int durationInSecs = 20;

			Welcome(N, durationInMins, durationInSecs);

			//
			// Create 100 tasks but set the Max Degree of Parallelism to the #
			// of cores reported by .NET, which will correctly prevent .NET from
			// trying to start all 100 tasks at the same time (and thus over-
			// subscribing the system):
			//
			ParallelOptions options = new ParallelOptions();
			options.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

			Parallel.For(0, N, options, (i) =>
				{
					OneLongRunningTask(durationInMins, durationInSecs);
				}
			);

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
		static void OneLongRunningTask(int durationInMins, int durationInSecs)
		{
			long durationInMilliSecs = durationInMins * 60 * 1000;
			durationInMilliSecs += (durationInSecs * 1000);

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

			Console.WriteLine("** Long-running Tasks App -- MaxDegreeOfParallelism [{0}, {1}] **", platform, version);
			Console.WriteLine("   Number of tasks: {0:#,##0}", N);
			Console.WriteLine("   Number of cores: {0:#,##0}", System.Environment.ProcessorCount);
			Console.WriteLine("   Task duration:   {0:#,##0} mins, {1:#,##0} secs", durationInMins, durationInSecs);
			Console.WriteLine();
		}

   }//class
}//namespace
