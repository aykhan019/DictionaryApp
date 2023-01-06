using DictionaryApp.Models;
using DictionaryApp.ViewModels;
using DictionaryApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace DictionaryApp.Helpers
{
    public static class Extensions
    {
        public static PartOfSpeech ToPartOfSpeechEnum(this string str)
        {
            switch (str.ToLower())
            {
                case "noun":
                    return PartOfSpeech.Noun;
                case "adverb":
                    return PartOfSpeech.Adverb;
                case "verb":
                    return PartOfSpeech.Verb;
                case "adjective":
                    return PartOfSpeech.Adjective;
                case "preposition":
                    return PartOfSpeech.Preposition;
                case "conjunction":
                    return PartOfSpeech.Conjunction;
                case "interjection":
                    return PartOfSpeech.Interjection;
                default:
                    break;
            }
            return (PartOfSpeech)0;
        }

        public static ObservableCollection<UIElement> TextsToTextUCs(this List<string> list)
        {
            var newList = new List<UIElement>();
            list.ForEach(item =>
            {
                var textUC = new TextUC();
                var text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(item);
                var textUCVM = new TextUCViewModel(text);
                textUC.DataContext = textUCVM;
                newList.Add(textUC);
            });
            return new ObservableCollection<UIElement>(newList);
        }

        public static string GetText(this RichTextBox rtb)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            string rtbContent = textRange.Text;

            return rtbContent;
        }

        public static string AddParagraph(this RichTextBox rtb, PageItemModel model)
        {
            string Text = "";

            Paragraph paragraph = new Paragraph();

            Run no_of_word_run = new Run(model.Rank.ToRoman() + "." + Constants.Space);
            no_of_word_run.Foreground = Brushes.Black;
            no_of_word_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
            no_of_word_run.FontWeight = FontWeights.Bold;
            no_of_word_run.FontSize = Constants.MainFontSize;

            Run word_run = new Run(model.Word);
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

            Run definition_run = new Run(model.Definition);
            definition_run.Foreground = Brushes.Black;
            definition_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
            definition_run.FontWeight = FontWeights.Bold;
            definition_run.FontSize = Constants.MainFontSize;

            Run example_run = new Run($"Example - {model.SentenceExample}");
            example_run.Foreground = Brushes.Black;
            example_run.FontFamily = new FontFamily(Constants.VocabularyMainFontFamily);
            example_run.FontWeight = FontWeights.Light;
            example_run.FontSize = Constants.MainFontSize;
            example_run.TextDecorations = TextDecorations.Underline;

            paragraph.Inlines.Add(no_of_word_run);
            paragraph.Inlines.Add(word_run);
            paragraph.Inlines.Add(dash_run);
            paragraph.Inlines.Add(definition_run);
            paragraph.Inlines.Add(new Run("\n"));
            paragraph.Inlines.Add(example_run);

            Text += no_of_word_run.Text;
            Text += word_run.Text;
            Text += dash_run.Text;
            Text += definition_run.Text;
            Text += "\n";
            Text += example_run.Text;

            paragraph.Margin = new Thickness(0, 20, 0, 0);
            rtb.Document.Blocks.Add(paragraph);
            return Text;
        }

        public static void AddWordsToView(this RichTextBox rtb)
        {
            foreach (var model in App.AddedWords)
            {
                model.Rank = ++App.WordCountInPage;
                rtb.AddParagraph(model);
            }
        }

        public static string ToRoman(this int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new Exception("Impossible state reached");
        }
    }
}
