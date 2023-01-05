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
