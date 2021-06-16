using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFBasic_ServiceLib
{
    public class TestService:WCFBasic_ContractLib.ITestService
    {
        //public String EchoOperation(String argument)
        //{
        //    WCFBasic_LegacyCode.Implementation _obj = new WCFBasic_LegacyCode.Implementation();
        //    return _obj.Echo(argument);
        //}

        string WCFBasic_ContractLib.ITestService.EchoOperation(string msg)
        {
             WCFBasic_LegacyCode.Implementation _obj = new WCFBasic_LegacyCode.Implementation();
            return _obj.Echo(msg);
        }   
    }
}
