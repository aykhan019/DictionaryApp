using DictionaryApp.Commands;
using DictionaryApp.Helpers;
using DictionaryApp.Views;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DictionaryApp.ViewModels
{
    public class DefinitionSentenceUCViewModel : BaseViewModel
    {
        public RelayCommand AddRemoveCommand { get; set; }

        public string Word { get; set; }

        private string definition;

        public string Definition
        {
            get { return definition; }
            set { definition = value; OnPropertyChanged(); }
        }

        private string sentenceExample;

        public string SentenceExample
        {
            get { return sentenceExample; }
            set { sentenceExample = value; OnPropertyChanged(); }
        }

        private string imageSource = Constants.AddSignImageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        private string toolTipText = Constants.ToolTipTextAdd;

        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; OnPropertyChanged(); }
        }

        public string RankOfWord { get; set; }

        public DefinitionSentenceUCViewModel()
        {
            AddRemoveCommand = new RelayCommand((a) =>
            {
                string example = string.Empty;
                if (SentenceExample.Contains("."))
                    example = "Sentence Example";
                else
                    example = "Example";

                if (ImageSource == Constants.AddSignImageSource)
                {
                    ImageSource = Constants.RemoveSignImageSource;
                    ToolTipText = Constants.ToolTipTextRemove;

                    Paragraph paragraph = new Paragraph();

                    RankOfWord = App.WordCountInPage.ToRoman();
                    Run no_of_word_run = new Run(RankOfWord + "." + Constants.Space);
                    no_of_word_run.Foreground = Brushes.Black;
                    no_of_word_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    no_of_word_run.FontWeight = FontWeights.Bold;
                    no_of_word_run.FontSize = Constants.MainFontSize;


                    Run word_run = new Run(Word);
                    //word_run.Foreground = Constants.WantedColor;
                    word_run.Foreground = App.MyDictionary["SeventhColor"] as SolidColorBrush;
                    word_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    word_run.FontWeight = FontWeights.Bold;
                    word_run.FontSize = Constants.MainFontSize;

                    Run dash_run = new Run(Constants.Dash);
                    dash_run.Foreground = Brushes.Black;
                    dash_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    dash_run.FontWeight = FontWeights.Bold;
                    dash_run.FontSize = Constants.MainFontSize;

                    Run definition_run = new Run(Definition);
                    definition_run.Foreground = Brushes.Black;
                    definition_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    definition_run.FontWeight = FontWeights.Bold;
                    definition_run.FontSize = Constants.MainFontSize;

                    Run e_run = new Run("Example - ");
                    e_run.Foreground = Brushes.Black;
                    e_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    e_run.FontWeight = FontWeights.Light;
                    e_run.FontSize = Constants.MainFontSize;
                    e_run.TextDecorations = TextDecorations.Underline;

                    Run example_run = new Run(SentenceExample);
                    example_run.Foreground = Brushes.Black;
                    example_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    example_run.FontWeight = FontWeights.Light;
                    example_run.FontSize = Constants.MainFontSize;
                    example_run.TextDecorations = TextDecorations.Underline;

                    paragraph.Inlines.Add(no_of_word_run);
                    paragraph.Inlines.Add(word_run);
                    paragraph.Inlines.Add(dash_run);
                    paragraph.Inlines.Add(definition_run);
                    paragraph.Inlines.Add(Environment.NewLine);
                    paragraph.Inlines.Add(e_run);

                    paragraph.Inlines.Add(example_run);
                    paragraph.Margin = new Thickness(0, 20, 0, 0);
                    App.Page.Document.Blocks.Add(paragraph);
                    App.Page.ScrollToEnd();
                    App.WordCountInPage++;
                }
                else
                {
                    Paragraph paragraph = new Paragraph();

                    Run no_of_word_run = new Run(RankOfWord + "." + Constants.Space);
                    no_of_word_run.Foreground = Brushes.Black;
                    no_of_word_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    no_of_word_run.FontWeight = FontWeights.Bold;
                    no_of_word_run.FontSize = Constants.MainFontSize;

                    Run word_run = new Run(Word);
                    //word_run.Foreground = Constants.WantedColor;
                    word_run.Foreground = App.MyDictionary["SeventhColor"] as SolidColorBrush;
                    word_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    word_run.FontWeight = FontWeights.Bold;
                    word_run.FontSize = Constants.MainFontSize;

                    Run dash_run = new Run(Constants.Dash);
                    dash_run.Foreground = Brushes.Black;
                    dash_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    dash_run.FontWeight = FontWeights.Bold;
                    dash_run.FontSize = Constants.MainFontSize;

                    Run definition_run = new Run(Definition);
                    definition_run.Foreground = Brushes.Black;
                    definition_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    definition_run.FontWeight = FontWeights.Bold;
                    definition_run.FontSize = Constants.MainFontSize;

                    Run e_run = new Run("Example - ");
                    e_run.Foreground = Brushes.Black;
                    e_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    e_run.FontWeight = FontWeights.Light;
                    e_run.FontSize = Constants.MainFontSize;
                    e_run.TextDecorations = TextDecorations.Underline;

                    Run example_run = new Run(SentenceExample);
                    example_run.Foreground = Brushes.Black;
                    example_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
                    example_run.FontWeight = FontWeights.Light;
                    example_run.FontSize = Constants.MainFontSize;
                    example_run.TextDecorations = TextDecorations.Underline;

                    paragraph.Inlines.Add(no_of_word_run);
                    paragraph.Inlines.Add(word_run);
                    paragraph.Inlines.Add(dash_run);
                    paragraph.Inlines.Add(definition_run);
                    paragraph.Inlines.Add(Environment.NewLine);
                    paragraph.Inlines.Add(e_run);

                    paragraph.Inlines.Add(example_run);
                    paragraph.Margin = new Thickness(0, 20, 0, 0);

                    App.Page.Document.Blocks.Remove(App.Page.Document.Blocks.Where(b => b == paragraph).First());

                    ImageSource = Constants.AddSignImageSource;
                    ToolTipText = Constants.ToolTipTextAdd;
                    App.WordCountInPage--;
                }
            });
        }

    }
}
