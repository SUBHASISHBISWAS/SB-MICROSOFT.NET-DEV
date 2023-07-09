The demos

  "100-tasks"
  "100-tasks-long-running"

are trying to execute 100, long-running, CPU-intensive tasks.  They
both over-subscribe the system by creating too many threads.

To witness this:  open Task Mgr, switch to processes view, add "threads" 
column, and then run each app.  Watch the thread count --- if we create 
too many threads, system will be over-subscribed and thrash due to all
the context switching.

Solutions?  Provided in after\ folder...
