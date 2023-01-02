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
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand GoForwardCommand { get; set; }

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

        private readonly object syncObject = new object();

        public HomePageViewModel()
        {
            SearchText = Constants.SearchDefaultText;

            GoBackCommand = new RelayCommand((g) =>
            {
                if (App.SearchedWordsIndex > 0)
                {
                    App.SearchedWordsIndex--;
                    SearchText = App.SearchedWords[App.SearchedWordsIndex];
                    SearchCommand.Execute(null);
                }
            });

            GoForwardCommand = new RelayCommand((g) =>
            {
                if (App.SearchedWordsIndex < App.SearchedWords.Count - 1)
                {
                    App.SearchedWordsIndex++;
                    SearchText = App.SearchedWords[App.SearchedWordsIndex];
                    SearchCommand.Execute(null);
                }
            });

            SearchCommand = new RelayCommand((s) =>
            {
                Items.Clear();
                App.MainColumnScroll.ScrollToTop();
                try
                {
                    SearchText = SearchText.Trim();
                    if (SearchText == string.Empty)
                        return;
                    string lastWord = String.Empty;
                    if (App.SearchedWords.Count > 0)
                    {
                        lastWord = App.SearchedWords.Last();
                    }

                    if (lastWord != String.Empty)
                    {
                        if (lastWord != SearchText)
                        {
                            App.SearchedWords.Add(SearchText);
                            App.SearchedWordsIndex++;
                        }
                    }
                    var result = DictionaryService.GetWordDetail(SearchText).Result;
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

                                var partOfSpeechUC = new WordDetailsUC();
                                var partOfSpeechUCVM = new WordDetailsUCViewModel(result, meaning);
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
                        var noResultUC = new NoResultUC();
                        var fromLeft = (App.MainColumn.ActualWidth - 516) / 2;
                        noResultUC.Margin = new Thickness(fromLeft, 100, 0, 0);
                        Items.Add(noResultUC);
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
