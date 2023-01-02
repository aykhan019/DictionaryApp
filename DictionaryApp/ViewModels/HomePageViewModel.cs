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
                try
                {
                    var result = DictionaryService.GetWordDetail(SearchText.Trim()).Result;

                    if (result != null)
                    {
                        var wordUC = new WordUC();
                        wordUC.Width = App.MainColumn.ActualWidth - 40;
                        var wordUCVM = new WordUCViewModel(result);
                        wordUC.DataContext = wordUCVM;
                        Items.Add(wordUC);

                        var partOfSpeeches = result.Meanings.Select(x => x.PartOfSpeech).ToList();
                        var hasDone = new List<string>();
                        foreach (var meaning in result.Meanings)
                        {
                            var currentPartOfSpeech = meaning.PartOfSpeech;
                            if (!hasDone.Contains(currentPartOfSpeech))
                            {
                                var meaningsWithSamePartOfSpeech = result.Meanings.Where(x => x.PartOfSpeech == currentPartOfSpeech);

                                var partOfSpeechUC = new WordInSpeechUC();
                                var partOfSpeechUCVM = new WordInSpeechUCViewModel(result, meaning);
                                partOfSpeechUC.DataContext = partOfSpeechUCVM;

                                foreach (var mw in meaningsWithSamePartOfSpeech)
                                {
                                    foreach (var d in mw.Definitions)
                                    {
                                        var definitionSentenceUC = new DefinitionSentenceUC();
                                        var definitionSentenceUCVM = new DefinitionSentenceUCViewModel()
                                        {
                                            Definition = d.Definition,
                                            SentenceExample = d.Example
                                        };
                                        if (definitionSentenceUCVM.SentenceExample == null || definitionSentenceUCVM.SentenceExample.Trim().Length == 0)
                                        {
                                            definitionSentenceUCVM.SentenceExample = Constants.NoSentenceExample;
                                        }
                                        definitionSentenceUC.DataContext = definitionSentenceUCVM;
                                        partOfSpeechUCVM.Items.Add(definitionSentenceUC);
                                    }
                                }
                                partOfSpeechUC.Width = App.MainColumn.ActualWidth - 40;
                                    Items.Add(partOfSpeechUC);
                                hasDone.Add(currentPartOfSpeech);
                            }
                        }
                    }
                    else
                    {
                        // show that no result was found
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            });

        }
    }
}
