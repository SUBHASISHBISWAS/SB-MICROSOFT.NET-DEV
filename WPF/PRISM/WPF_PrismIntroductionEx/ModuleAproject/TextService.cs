using InterfacesProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleAproject
{
    class TextService:ITextService
    {
        public string GetText()
        {
            return "Hello World";
        }
    }
}
