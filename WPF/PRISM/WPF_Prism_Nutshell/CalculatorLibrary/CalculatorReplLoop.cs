using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace WPFBasic_FirstPrismEx
{
   public  class CalculatorReplLoop : ICalculatorReplLoop
   {
       private ICalculator calculator;
       private IInputService inputService;
       //private IOutputService outputService;
       private InputPerserService parsingService;

       private List<IOutputService> outputServices;

       //public CalculatorReplLoop(ICalculator calculator, IInputService inputService, IOutputService outputService, InputPerserService parsingService)
       //{
       //    this.calculator = calculator;
       //    this.inputService = inputService;
       //    this.outputService = outputService;
       //    this.parsingService = parsingService;
       //}


       public CalculatorReplLoop(IUnityContainer container, ICalculator calculator, IInputService inputService, InputPerserService parsingService)
       {
           this.calculator = calculator;
           this.inputService = inputService;
           this.parsingService = parsingService;
           outputServices=new List<IOutputService>(container.ResolveAll<IOutputService>());
       }
       
       //[Dependency]
       //public ICalculator Calculator
       //{
       //    get { return calculator; }
       //    set { calculator = value; }
       //}

       //[Dependency]
       //public IInputService InputService
       //{
       //    get { return inputService; }
       //    set { inputService = value; }
       //}

       //[Dependency]
       //public IOutputService OutputService
       //{
       //    get { return outputService; }
       //    set { outputService = value; }
       //}

       //[Dependency]
       //public InputPerserService ParsingService
       //{
       //    get { return parsingService; }
       //    set { parsingService = value; }
       //}


       public CalculatorReplLoop()
       {
          
       }
        public void Run()
        {
            while (true)
            {
                string command = inputService.ReadCommand();

                try
                {
                    CommandTypes commandType = parsingService.ParseCommand(command);
                    Arguments args = inputService.ReadArguments();
                    WiteMessages(calculator.Execute(commandType, args).ToString());
                }
                catch 
                {

                    Console.WriteLine("Error!");
                }
            }

            
        }

       private void WiteMessages(string message)
       {
           foreach (var outputService in outputServices)
           {
               outputService.WriteMessage(message);
           }
       }
    }
}
