﻿using Subhasish.Libraries.UI.Bootstrappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Subhasish.Apps.OrderSystem.RichUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void HandleApplicationStartUp(object sender, StartupEventArgs e)
        {
            var bootStrapper = new OrderSystemBootstrapper();
            bootStrapper.Run();
        }
    }
}
