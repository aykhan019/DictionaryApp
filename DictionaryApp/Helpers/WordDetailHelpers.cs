using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
}
