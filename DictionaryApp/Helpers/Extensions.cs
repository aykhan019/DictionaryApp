using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
    }
}
