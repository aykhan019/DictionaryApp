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
    }
}
