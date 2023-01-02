using DictionaryApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Grid PageGrid { get; internal set; }
        public static Grid MainColumn { get; internal set; }
        public static Grid SecondColumn { get; internal set; }
    }
}
