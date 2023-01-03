using DictionaryApp.Commands;
using DictionaryApp.Helpers;
using DictionaryApp.Models;
using DictionaryApp.Models.WordModels;
using DictionaryApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DictionaryApp.ViewModels
{
    public class WordDetailsUCViewModel : BaseViewModel
    {
        public RelayCommand CollapseExpandCommand { get; set; }

        private WordDetailsUCModel wordDetailsUCModel;

        public WordDetailsUCModel WordDetailsUCModel
        {
            get { return wordDetailsUCModel; }
            set { wordDetailsUCModel = value; }
        }

        public WordDetailsUCViewModel(string word, string partOfSpeech)
        {
            wordDetailsUCModel = new WordDetailsUCModel(word, partOfSpeech);

            CollapseExpandCommand = new RelayCommand((c) =>
            {
                if (WordDetailsUCModel.IsExpanded)
                {
                    WordDetailsUCModel.ImageSource = Constants.ExpandArrowImageSource;
                }
                else
                {
                    WordDetailsUCModel.ImageSource = Constants.CollapseArrowImageSource;
                }
                WordDetailsUCModel.IsExpanded = !WordDetailsUCModel.IsExpanded;
            });
        }
    }
}
