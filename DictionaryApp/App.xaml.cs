using DictionaryApp.Helpers;
using DictionaryApp.ViewModels;
using DictionaryApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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
        public static HomePageViewModel HomePageVM { get; internal set; }
        public static List<string> SearchedWords { get; set; } = new List<string>();
        public static int SearchedWordsIndex { get; set; } = -1;
        public static ScrollViewer MainColumnScroll { get; internal set; }
        public static ResourceDictionary MyDictionary { get; set; } = (ResourceDictionary)LoadComponent(new Uri("/DictionaryApp;component/Dictionaries/MyDictionary.xaml", UriKind.Relative));
        public static RichTextBox Page { get; set; }
        public static int WordCountInPage { get; set; } = 1;
    }
}
