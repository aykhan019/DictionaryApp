using DictionaryApp.Models;
using DictionaryApp.ViewModels;
using DictionaryApp.Views;
using System.Speech.Synthesis;
using System.Threading;
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
            App.SecondColumn = homePageView.SecondColumn;
            var homePageViewModel = new HomePageViewModel();
            homePageView.DataContext = homePageViewModel;
            App.MainColumnScroll = homePageView.MainColumnScroll;
            App.HomePageVM = homePageViewModel;
            App.PageGrid.Children.Add(homePageView);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var view = (App.PageGrid.Children[0] as HomePageUC);
            var width = App.MainColumn.ActualWidth - 40;
            view.SearchTB.Width = width - 60;
        }
    }
}
