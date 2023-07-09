using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomSchedulerExample
{
    public class SingleThreadTaskScheduler : TaskScheduler
    {
        private BlockingCollection<Task> _tasks =
            new BlockingCollection<Task>();

        private Thread _taskThread;

        public SingleThreadTaskScheduler()
        {
            _taskThread = new Thread(ThreadMain);
            _taskThread.Name = "Single Thread Scheduler";
            _taskThread.Start();
        }

        public override int MaximumConcurrencyLevel
        {
            get
            {
                return 1;
            }
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks.ToArray();
        }

        protected override void QueueTask(Task task)
        {
            _tasks.Add(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (!taskWasPreviouslyQueued && Thread.CurrentThread == _taskThread)
            {
                return TryExecuteTask(task);
            }
            return false;
        }

        private void ThreadMain()
        {
            while (true)
            {
                Task t = _tasks.Take();
                TryExecuteTask(t);
            }
        }
    }
}
