using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ProducerConsumer
    {
        //public static void Main()
        //{
        //    Cell cell = new Cell();
        //    CellProducer cellproducer = new CellProducer(20, cell);
        //    CellConsumer cellConsumer = new CellConsumer(20, cell);

        //    Thread producer = new Thread(cellproducer.ThreadStart);
        //    Thread consumer = new Thread(cellConsumer.ThreadStart);

        //    consumer.Start();
        //    producer.Start();
        //    consumer.Join();
        //    producer.Join();
        //}

       
    }

    public class CellProducer
    {
        int myLoopCount = 1;
        Cell myCell;
        public CellProducer(int numberOfCell,Cell cell)
        {
            myCell = cell;
            myLoopCount = numberOfCell;
        }

        public void ThreadStart()
        {
            for (int i = 0; i < myLoopCount; i++)
            {
                myCell.WriteToCell(i);
            }
        }


    }

    public class CellConsumer
    {
        int myLoopCount = 1;
        Cell myCell;
        public CellConsumer(int numberOfCell, Cell cell)
        {
            myCell = cell;
            myLoopCount = numberOfCell;
        }

        public void ThreadStart()
        {
            for (int i = 0; i < myLoopCount; i++)
            {
                myCell.ReadFromCell();
            }
        }

    }

   

    public class Cell
    {
         private static void OptimizedAway() 
         {
            // Constant expression is computed at compile time resulting in zero
            Int32 value = (1 * 100) - (50 * 2);
            // If value is 0, the loop never executes
            for (Int32 x = 0; x < value; x++) {
                // There is no need to compile the code in the loop since it can never execute
               Console.WriteLine("Jeff");
            }
         }
        int CellCount;
        bool flag;
        public void WriteToCell(int i)
        {
            lock (this)
            {
                if (flag)
                {
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                CellCount = i;
                Console.WriteLine("Produce:{0}",CellCount);
                flag = true;
                Monitor.Pulse(this);
               
            }

            
        }

        public int ReadFromCell()
        {
            lock (this)
            {
                if (!flag)
                {
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
                Console.WriteLine("Consume:{0}",CellCount);
                flag = false;
                Monitor.Pulse(this);
            }

            return CellCount;
        }
    }
}
