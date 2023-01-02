using DictionaryApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DictionaryApp.ViewModels
{
    public class TextUCViewModel : BaseViewModel
    {
        public RelayCommand SearchWordCommand { get; set; }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); }
        }

        public TextUCViewModel(string _text)
        {
            Text = _text;

            SearchWordCommand = new RelayCommand((s) =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    App.HomePageVM.SearchText = Text;
                    App.HomePageVM.SearchCommand.Execute(null);
                });
            });
        }
    }
}
