using DictionaryApp.Commands;
using DictionaryApp.Helpers;
using DictionaryApp.Services;
using DictionaryApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DictionaryApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public RelayCommand SearchCommand { get; set; }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged(); }
        }

        private ObservableCollection<UIElement> items = new ObservableCollection<UIElement>();

        public ObservableCollection<UIElement> Items
        {
            get { return items; }
            set { items = value; OnPropertyChanged(); }
        }


        public HomePageViewModel()
        {
            SearchText = Constants.SearchDefaultText;

            SearchCommand = new RelayCommand((s) =>
            {
                Items.Clear();
                dynamic result;
                try
                {
                    result = DictionaryService.GetWordDetail(SearchText.Trim()).Result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (result != null)
                {
                    var wordUC = new WordUC();
                    wordUC.Width = App.MainColumn.ActualWidth - 40;
                    var wordUCVM = new WordUCViewModel(result);
                    wordUC.DataContext = wordUCVM;
                    Items.Add(wordUC);
                    wordUC.Height += 1000;
                }
                else
                {

                }
            });

        }
    }
}
