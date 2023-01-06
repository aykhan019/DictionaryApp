using DictionaryApp.Commands;
using DictionaryApp.Helpers;
using DictionaryApp.Models;
using DictionaryApp.Services;
using DictionaryApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace DictionaryApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand GoForwardCommand { get; set; }

        public RelayCommand MouseEnterCommand { get; set; }
        public RelayCommand MouseLeaveCommand { get; set; }
        public RelayCommand IsFocusedCommand { get; set; }
        public RelayCommand IsNotFocusedCommand { get; set; }

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

        private SolidColorBrush color;

        public SolidColorBrush ScrollColor
        {
            get { return color; }
            set { color = value; OnPropertyChanged(); }
        }

        private bool IsFocused;

        private SolidColorBrush foreground;

        public SolidColorBrush Foreground
        {
            get { return foreground; }
            set { foreground = value; OnPropertyChanged(); }
        }

        public bool AddWord { get; set; } = true;

        public HomePageViewModel()
        {
            Foreground = App.MyDictionary["ThirdColor"] as SolidColorBrush;

            ScrollColor = App.MyDictionary["MainColorDarker"] as SolidColorBrush;

            SearchText = Constants.SearchDefaultText;

            MouseEnterCommand = new RelayCommand((m) =>
            {
                if (SearchText.Trim() == Constants.SearchDefaultText)
                {
                    SearchText = String.Empty;
                }
            });

            MouseLeaveCommand = new RelayCommand((m) =>
            {
                if (SearchText.Trim() == String.Empty && IsFocused == false)
                {
                    SearchText = Constants.SearchDefaultText;
                }
            });

            IsFocusedCommand = new RelayCommand((i) =>
            {
                IsFocused = true;
                Foreground = App.MyDictionary["FifthColor"] as SolidColorBrush;
            });

            IsNotFocusedCommand = new RelayCommand((i) =>
            {
                IsFocused = false;
                string text = SearchText.Trim();
                if (text == String.Empty || text == Constants.SearchDefaultText)
                {
                    Foreground = App.MyDictionary["ThirdColor"] as SolidColorBrush;

                    SearchText = Constants.SearchDefaultText;
                }
            });

            GoBackCommand = new RelayCommand((g) =>
            {
                if (App.SearchedWordsIndex > 0)
                {
                    App.SearchedWordsIndex--;
                    SearchText = App.SearchedWords[App.SearchedWordsIndex];
                    SearchCommand.Execute(null);
                    AddWord = false;
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

            SearchCommand = new RelayCommand(async (s) =>
            {
                try
                {
                    SearchText = SearchText.Trim();
                    if (SearchText == string.Empty || SearchText == Constants.SearchDefaultText)
                        return;
                    Items.Clear();
                    var loadingAnimation = new LoadingAnimation();
                    var marginFromLeft = (App.MainColumn.ActualWidth - 100) / 2;
                    loadingAnimation.Margin = new Thickness(marginFromLeft, 50, 0, 0);
                    Items.Add(loadingAnimation);
                    App.MainColumnScroll.ScrollToTop();

                    var results = await DictionaryService.GetWordDetail(SearchText);
                    if (AddWord)
                    {
                        App.SearchedWords.Add(SearchText);
                        App.SearchedWordsIndex++;
                    }
                    Items.Clear();

                    if (results != null)
                    {
                        var wordUC = new WordUC();
                        wordUC.Width = App.MainColumn.ActualWidth - 40;
                        var wordUCVM = new WordUCViewModel(results.First());
                        wordUC.DataContext = wordUCVM;
                        Items.Add(wordUC);

                        var listOfMeanings = results.Select(r => r.Meanings).ToList();
                        var partOfSpeeches = new List<string>();
                        listOfMeanings.ForEach(m => m.ForEach(p => partOfSpeeches.Add(p.PartOfSpeech)));
                        partOfSpeeches = partOfSpeeches.Distinct().ToList();

                        foreach (var pos in partOfSpeeches)
                        {
                            // Get all definitons for particular part of speech
                            var definitionsWithSamePartOfSpeech = new List<DefinitionOfWord>();
                            listOfMeanings.ForEach(l => l.Where(b => b.PartOfSpeech == pos).ToList().ForEach(m => m.Definitions.ForEach(d => definitionsWithSamePartOfSpeech.Add(d))));

                            // Creating WordDetailUC
                            var wordDetailUC = new WordDetailsUC();
                            wordDetailUC.Width = App.MainColumn.ActualWidth - 40;
                            var wordDetailUCVM = new WordDetailsUCViewModel(SearchText, pos);
                            wordDetailUC.DataContext = wordDetailUCVM;
                            // Adding definitions to the WordDetailUC
                            foreach (var definition in definitionsWithSamePartOfSpeech)
                            {
                                var definitionSentenceUC = new DefinitionSentenceUC();
                                var definitionSentenceUCVM = new DefinitionSentenceUCViewModel()
                                {
                                    Word = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(SearchText.Trim()),
                                    Definition = definition.Definition,
                                    SentenceExample = definition.Example
                                };
                                if (definitionSentenceUCVM.SentenceExample == null || definitionSentenceUCVM.SentenceExample.Trim().Length == 0)
                                {
                                    definitionSentenceUCVM.SentenceExample = Constants.NoSentenceExample;
                                }
                                definitionSentenceUCVM.model = new PageItemModel
                                {
                                    Definition = definitionSentenceUCVM.Definition,
                                    SentenceExample = definitionSentenceUCVM.SentenceExample,
                                    Word = definitionSentenceUCVM.Word,
                                };
                                definitionSentenceUC.DataContext = definitionSentenceUCVM;
                                wordDetailUCVM.WordDetailsUCModel.Items.Add(definitionSentenceUC);
                            }
                            // Getting Synonyms and Antonyms
                            var listOfSynonyms = new List<string>();
                            var listOfAntonyms = new List<string>();
                            //listOfMeanings.ForEach(l => l.Where(b => b.PartOfSpeech == pos).ToList().ForEach(m => listOfSynonyms.AddRange(m.Synonyms)));

                            listOfMeanings.ForEach(l => l
                                          .Where(b => b.PartOfSpeech == pos)
                                          .ToList()
                                          .ForEach(m =>
                                          {
                                              listOfSynonyms.AddRange(m.Synonyms);
                                              listOfAntonyms.AddRange(m.Antonyms);
                                              m.Definitions.ForEach(d =>
                                              {
                                                  listOfSynonyms.AddRange(d.Synonyms);
                                                  listOfAntonyms.AddRange(d.Antonyms);
                                              });
                                          }));

                            listOfSynonyms = listOfSynonyms.Distinct().ToList();
                            listOfAntonyms = listOfAntonyms.Distinct().ToList();

                            if (listOfSynonyms.Count > 0)
                                wordDetailUCVM.WordDetailsUCModel.Synonyms = listOfSynonyms.TextsToTextUCs();
                            else
                            {
                                var noSynonymUC = new TextUC();
                                noSynonymUC.TextTB.TextDecorations = null;
                                noSynonymUC.TextTB.Cursor = Cursors.Arrow;
                                noSynonymUC.TextTB.Foreground = App.MyDictionary["SeventhColor"] as SolidColorBrush;
                                var noSynonymUCVM = new TextUCViewModel(Constants.NoSynonyms);
                                noSynonymUCVM.SearchWordCommand = null;
                                noSynonymUC.DataContext = noSynonymUCVM;
                                wordDetailUCVM.WordDetailsUCModel.Synonyms.Add(noSynonymUC);
                            }

                            if (listOfAntonyms.Count > 0)
                                wordDetailUCVM.WordDetailsUCModel.Antonyms = listOfAntonyms.TextsToTextUCs();
                            else
                            {
                                var noAntonym = new TextUC();
                                noAntonym.TextTB.TextDecorations = null;
                                noAntonym.TextTB.Cursor = Cursors.Arrow;
                                noAntonym.TextTB.Foreground = App.MyDictionary["SeventhColor"] as SolidColorBrush;
                                var noAntonymVM = new TextUCViewModel(Constants.NoAntonyms);
                                noAntonymVM.SearchWordCommand = null;
                                noAntonym.DataContext = noAntonymVM;
                                wordDetailUCVM.WordDetailsUCModel.Antonyms.Add(noAntonym);
                            }

                            Items.Add(wordDetailUC);
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
                    MessageBox.Show("An Error Occured : " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                AddWord = true;
            });

        }
    }
}
