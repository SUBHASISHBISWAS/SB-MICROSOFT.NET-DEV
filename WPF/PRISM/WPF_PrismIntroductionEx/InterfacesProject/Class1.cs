using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterfacesProject
{
    public interface ITextService
    {
        string GetText();
    }

    public interface IUIService
    {
        UIElement GetUI();
    }

}
