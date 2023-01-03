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
            var vm = view.DataContext as HomePageViewModel;
            var width = App.MainColumn.ActualWidth - 40;
            foreach (var item in vm.Items)
            {
                //item.Measure(new Size(App.MainColumn.ActualWidth, 0));
                if (item is WordUC w)
                {
                    w.Width = width;
                }
                if (item is WordDetailsUC w2)
                {
                    w2.Width = width;
                }
                if (item is LoadingAnimation la)
                {
                    var marginFromLeft = (width - 100) / 2;
                    la.Margin = new Thickness(marginFromLeft, 50, 0, 0);
                }
            }
            view.SearchTB.Width = width - 60;
            //if (App.MainColumnInitialWidth != width)
            //{
            //    view.SearchTB.Height = App.SearchTBHeight;
            //    view.SearchGrid.Height= view.SearchGrid.ActualHeight + 20;
            //}
            //view.SearchTB.Height = view.SearchTB.ActualHeight + 20;
        }
    }
}
