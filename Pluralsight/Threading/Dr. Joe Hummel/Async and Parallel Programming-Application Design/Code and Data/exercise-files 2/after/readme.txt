In the before\ folder there are 2 apps that are trying to execute 100,
long-running, CPU-intensive tasks.  They both over-subscribe the system
by creating too many threads.  Here are 2 better designs:

 1. "100-tasks-1-per-core":
     Create tasks 1 per core, as each task finishes create another.
     We do this ourselves, explicitly.

 2. "100-tasks-MaxDegreeOfParallelism":
     Create tasks 1 per core, but have .NET do this for us by
     using a Parallel.For loop and providing the MaxDegreeOfParallelism
     option.

