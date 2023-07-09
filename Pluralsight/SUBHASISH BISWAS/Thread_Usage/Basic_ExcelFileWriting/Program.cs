using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;


namespace Debugging
{
    /*
    class Program
    {
        static EventWaitHandle _ready=new AutoResetEvent( false );
        static EventWaitHandle _go = new AutoResetEvent(false);
        static  readonly object _locker=new object();
        private static string _message = null;
        static void Main(string[] args)
        {
            new Thread( Waiter).Start();
            
            _ready.WaitOne();
            Console.WriteLine("Main Notified");
            lock( _locker )
            {
                _message = "oooo";
            }
            _go.Set();

            _ready.WaitOne();
            lock (_locker)
            {
                _message = "ahhh";
            }
            _go.Set();

            _ready.WaitOne();
            lock (_locker)
            {
                _message = null;
            }
            _go.Set();
        }

        static void Waiter()
        {
            while( true )
            {
                Console.WriteLine( "READY-SET" );
                _ready.Set();
                Console.WriteLine( "Worker Blocked" );
                _go.WaitOne();
                lock( _locker )
                {
                    if( _message==null )
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine( _message );
                    }
                }
            }
        }
    }

    internal sealed class Transaction
    {
        private DateTime m_timeOfLastTrans;
        public void PerformTransaction()
        {
            Monitor.Enter(this);
            // This code has exclusive access to the data...
            m_timeOfLastTrans = DateTime.Now;
            Monitor.Exit(this);
        }
        public DateTime LastTransaction
        {
            get
            {
                Monitor.Enter(this);
                // This code has shared access to the data...
                DateTime temp = m_timeOfLastTrans;
                Monitor.Exit(this);
                return temp;
            }
        }

        public static void SomeMethod()
        {
            var t = new Transaction();
            Monitor.Enter(t); // This thread takes the object's public lock
            // Have a thread pool thread display the LastTransaction time
            // NOTE: The thread pool thread blocks until SomeMethod calls Monitor.Exit!
            ThreadPool.QueueUserWorkItem(o => Console.WriteLine(t.LastTransaction));
            // Execute some other code here...
            Monitor.Exit(t);
        }
    }


    internal sealed class Transaction
    {
        private readonly Object m_lock = new Object(); // Each transaction has a PRIVATE lock now
        private DateTime m_timeOfLastTrans;
        public void PerformTransaction()
        {
            Monitor.Enter(m_lock); // Enter the private lock
            // This code has exclusive access to the data...
            m_timeOfLastTrans = DateTime.Now;
            Monitor.Exit(m_lock); // Exit the private lock
        }
        public DateTime LastTransaction
        {
            get
            {
                Monitor.Enter(m_lock); // Enter the private lock
                // This code has shared access to the data...
                DateTime temp = m_timeOfLastTrans;
                Monitor.Exit(m_lock); // Exit the private lock
                return temp;
            }
        }

        private void SomeMethod()
        {
            lock (this)
            {
                // This code has exclusive access to the data...
            }
        }

        private void SomeMethod()
        {
            Boolean lockTaken = false;
            try
            {
                //
                Monitor.Enter(this, ref lockTaken);
                // This code has exclusive access to the data...
            }
            finally
            {
                if (lockTaken) Monitor.Exit(this);
            }
        }
    }

    internal class ThreadSafe
    {
        private List<string> _list = new List<string>();

        private void Test()
        {
            lock( this )
            {
                
            }

            lock( typeof(ThreadSafe) )
            {
                
            }
        }
    }
     * */


    public class DocumentObject
    {
        private string myMethodName;
        private string myTestStatus;
        private string myErrorMessage;
        private string myExceptionDetails;
        private string myFailedMethodName;

        public string MethodName
        {
            get
            {
                return myMethodName;
            }
            set
            {
                myMethodName = value;
            }
        }

        public string TestStatus
        {
            get
            {
                return myTestStatus;
            }
            set
            {
                myTestStatus = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return myErrorMessage;
            }
            set
            {
                myErrorMessage = value;
            }
        }

        public string ExceptionDetails
        {
            get
            {
                return myExceptionDetails;
            }
            set
            {
                myExceptionDetails = value;
            }
        }

        public string FailedMethodName
        {
            get
            {
                return myFailedMethodName;
            }
            set
            {
                myFailedMethodName = value;
            }
        }
    }

    public class ReadXml
    {
        public static void Main()
        {
            XElement xDoc = XElement.Load( @"E:\XML\TestRun.xml" );

            DocumentObject failedDocumentObject = null;
            List<DocumentObject> listOfFailedDocumentObject=new List<DocumentObject>();

            DocumentObject passedDocumentObject = null;
            List<DocumentObject> listOfPasseddDocumentObject = new List<DocumentObject>();

            foreach (var rootElement in xDoc.Elements())
            {
                foreach (var firstLevelElement in rootElement.Descendants())
                {
                    XElement resultElement = null;
                    if( firstLevelElement.Name.LocalName.Equals("name") )
                    {
                        XElement nameElement=firstLevelElement;
                        foreach( var nextElements in firstLevelElement.ElementsAfterSelf() )
                        {
                            if (nextElements.Name.LocalName.Equals("result"))
                            {
                                resultElement = nextElements;
                                break;
                            }
                        }
                        if( resultElement!=null )
                        {
                            foreach (var result in resultElement.Descendants())
                            {
                                if( result.Name.LocalName.Equals( "outcome" ) )
                                {
                                    if( result.Value.Equals( "Failed" ) )
                                    {
                                        failedDocumentObject = new DocumentObject();
                                        failedDocumentObject.TestStatus = result.Value;
                                        foreach( var nestedElement in result.ElementsAfterSelf() )
                                        {
                                            if( nestedElement.Name.LocalName.Equals("message") )
                                            {
                                                failedDocumentObject.ErrorMessage = nameElement.Value;
                                            }
                                            else if (nestedElement.Name.LocalName.Equals("exception"))
                                            {
                                                failedDocumentObject.ExceptionDetails = nestedElement.Value;
                                            }
                                            else if (nestedElement.Name.LocalName.Equals("failedChildName"))
                                            {
                                                failedDocumentObject.FailedMethodName = nestedElement.Value;
                                            }
                                        }
                                        failedDocumentObject.MethodName = firstLevelElement.Value.Remove( 0,25 );
                                        listOfFailedDocumentObject.Add(failedDocumentObject);
                                    }
                                    else if (result.Value.Equals("Passed"))
                                    {
                                        passedDocumentObject = new DocumentObject();
                                        passedDocumentObject.MethodName = firstLevelElement.Value;

                                        listOfPasseddDocumentObject.Add(passedDocumentObject);
                                    }
                                    
                                }
                                
                            } 
                        }
                    }
                }
                
                
                
            }

            var sh = GetWorkSheet();
            var aRange = sh.Range["A1", "E100"];

            var data = new string[100, 6];
            data[0, 1] = "TestCase";
            data[0, 2] = "Status";
            data[0, 3] = "Method Name";
            data[0, 4] = "Error Message";
            data[0, 5] = "Exception details";

            for (int row = 1; row < listOfFailedDocumentObject.Count; row++)
            {
                for (int col = 1; col < 6; col++)
                {
                    if (col == 1)
                    {
                        data[row, col] = listOfFailedDocumentObject[row].MethodName;
                    }
                    else if (col == 2)
                    {
                        data[row, col] = listOfFailedDocumentObject[row].TestStatus;
                    }
                    else if (col == 3)
                    {
                        data[row, col] = listOfFailedDocumentObject[row].FailedMethodName;
                    }
                    else if (col == 4)
                    {
                        data[row, col] = listOfFailedDocumentObject[row].ErrorMessage;
                    }
                    else if (col == 5)
                    {
                        data[row, col] = listOfFailedDocumentObject[row].ExceptionDetails;
                    }

                }
            }
            object m = Type.Missing;
            aRange.Columns.AutoFit();
            aRange.set_Value(m, data);

            
        }

        public static Excel.Worksheet GetWorkSheet()
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook wb = excel.Workbooks.Open(@"E:\XML\Report.xlsx");
            Excel.Worksheet sh = wb.Sheets.Add();
            sh.Name = "Hello";
            return sh;
        }
       
        public static void Logic_1()
        {
            XElement xDoc = XElement.Load(@"E:\XML\TestRun.xml");

            foreach (var element in xDoc.Elements())
            {
                var innerElemntsFirstLevel = element.Elements();
                foreach (var firstLevelElement in innerElemntsFirstLevel)
                {
                    var innerElemntsSecondLevel = firstLevelElement.Elements();

                    foreach (var secondLevelElement in innerElemntsSecondLevel)
                    {
                        var innerElemntsThirdLevel = secondLevelElement.Elements();

                        foreach (var thirdLevelElement in innerElemntsThirdLevel)
                        {
                            if (thirdLevelElement.Name.LocalName.Equals("result"))
                            {
                                if (thirdLevelElement.Value.Contains("Passed"))
                                {
                                    Console.WriteLine(thirdLevelElement.Value);
                                    //Console.WriteLine( thirdLevelElement.Parent );
                                }
                                foreach (var xElement in thirdLevelElement.Descendants())
                                {
                                    Console.WriteLine(xElement);
                                }

                            }

                        }
                    }

                }

            } 
        }
    }
}
