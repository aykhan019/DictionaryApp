using DictionaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DictionaryApp.Helpers
{
    public enum PartOfSpeech
    {
        [DisplayText("Noun")]
        Noun,

        [DisplayText("Adverb")]
        Adverb,

        [DisplayText("Verb")]
        Verb,

        [DisplayText("Adjective")]
        Adjective,

        [DisplayText("Preposition")]
        Preposition,

        [DisplayText("Conjunction")]
        Conjunction,

        [DisplayText("Pronoun")]
        Pronoun,

        [DisplayText("Interjection")]
        Interjection,
    }
    internal class DisplayText : Attribute
    {

        public DisplayText(string Text)
        {
            this.text = Text;
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }

    public static class WordDetailHelpers
    {
        public static List<string> GetSynonymsOfWord(WordDetail wordDetail)
        {
            var synonyms = new List<string>();
            foreach (var m in wordDetail.Meanings)
            {
                synonyms.AddRange(m.Synonyms.Select(x => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(x)));
                foreach (var d in m.Definitions)
                {
                    synonyms.AddRange(m.Synonyms.Select(x => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(x)));
                }
            }
            return synonyms.Distinct().ToList();
        }

        public static List<string> GetAntonymsOfWord(WordDetail wordDetail)
        {
            var antonyms = new List<string>();
            foreach (var m in wordDetail.Meanings)
            {
                antonyms.AddRange(m.Antonyms.Select(x => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(x)));
                foreach (var d in m.Definitions)
                {
                    antonyms.AddRange(m.Antonyms.Select(x => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(x)));
                }       
            }
            return antonyms.Distinct().ToList();
        }
    }
}
