using DictionaryApp.Models;
using DictionaryApp.ViewModels;
using DictionaryApp.Views;
using System.Speech.Synthesis;
using System.Windows;

namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.PageGrid = MyGrid;
            var homePageView = new HomePageUC();
            App.MainColumn = homePageView.MainColumn;
            var homePageViewModel = new HomePageViewModel();
            homePageView.DataContext = homePageViewModel;
            App.PageGrid.Children.Add(homePageView);
            //homePageViewModel.SearchCommand.Execute(null);  
        }
    }
}
