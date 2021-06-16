using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculatorService" in both code and config file together.
    [GlobalErrorHandlerBehaviour(typeof(GlobalErrorHandler))]
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int Numerator, int Denomerator)
        {
            //if (Denomerator==0)
            //{
            //    throw new FaultException("Denominator Cannot BeZero", new FaultCode("DevideByZeroFault"));
            //}

            //try
            //{
            //    return Numerator / Denomerator;
            //}
            //catch (DivideByZeroException exception)
            //{
            //    var dividebyzeroFault = new DivideByZeroFault()
            //    {
            //        Error = exception.Message,
            //        Details = "Denominator canot be Zero"
            //    };

            //    throw new FaultException<DivideByZeroFault>(dividebyzeroFault);
            //}

            return Numerator / Denomerator;
        }

        
    }
}
