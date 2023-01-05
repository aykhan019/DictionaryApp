using DictionaryApp.Helpers;
using DictionaryApp.Models;
using DictionaryApp.ViewModels;
using DictionaryApp.Views;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

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
            App.Page = homePageView.Page;

            var paragraph = new Paragraph();
            var run = new Run(Constants.VocabularyHeadline);
            run.Foreground = Brushes.Black;
            run.FontFamily = new FontFamily(Constants.VocabularyHeadlineFontFamily);
            run.FontWeight = FontWeights.Bold;
            run.FontSize = Constants.HeadlineFontSize;
            paragraph.Inlines.Add(run);
            paragraph.TextAlignment= TextAlignment.Center;
            App.Page.Document.Blocks.Add(paragraph);

            homePageView.DataContext = homePageViewModel;
            App.MainColumnScroll = homePageView.MainColumnScroll;
            App.HomePageVM = homePageViewModel;
            App.PageGrid.Children.Add(homePageView);
            //App.AddTextToPage(Constants.VocabularyHeadline, Constants.VocabularyHeadlineFontFamily, Constants.HeadlineFontSize, Brushes.Black, FontWeights.Bold, TextAlignment.Center);
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
        }
    }
}
