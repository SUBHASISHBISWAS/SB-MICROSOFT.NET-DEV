using InterfacesProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ModuleBProject
{
    class UIService : IUIService
    {
        private ITextService textService;

        public UIService(ITextService textService )
        {
            this.textService = textService;
        }

        public UIElement GetUI()
        {
            return new TextBlock()
            {
                Text=textService.GetText()
            };

        }
    }
}
