There are multiple versions of the "Search Log Files" app:

 SearchLogFiles-Seq: sequential version that works well for small and
   modest-sized files (e.g. < 50MB).  Easiest to understand, the version
   used in the lectures for demo purposes (at least the first one used).

 SearchLogFiles-Seq_timings: identical to first version except it breaks
   out the timings for I/O vs. string conversion vs. search.  Gives a 
   better sense of where time is being spent, and impact of parallelization.

As mentioned in "setup.doc", you need to install a set of log files to
into the relevant bin\Debug\logfiles or bin\Release\logfiles sub-folder.
You can copy the 4 pre-generated log files from "datafiles\logfiles", or
generate your own log files to create more interesting test cases (large
files, thousands of small files, etc.).  To generate log files, use the 
app "datafiles\GenRandomLogFiles" as discussed in "setup.doc".  


NOTE: these demos do not handle large files (e.g. 500MB or larger files
will cause "out of memory" exceptions).  The next lecture presents an 
updated design that handles files of arbitrary size:  see the demo

 SearchLogFiles-Seq-BigFile: version that supports files of any size, 
   GBs if necessary, at the cost of code complexity.
