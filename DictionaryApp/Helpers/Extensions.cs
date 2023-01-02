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
            switch (str)
            {
                case "Noun":
                    return PartOfSpeech.Noun;
                case "Adverb":
                    return PartOfSpeech.Adverb;
                case "Verb":
                    return PartOfSpeech.Verb;
                case "Adjective":
                    return PartOfSpeech.Adjective;
                case "Preposition":
                    return PartOfSpeech.Preposition;
                case "Conjunction":
                    return PartOfSpeech.Conjunction;
                case "Interjection":
                    return PartOfSpeech.Interjection;
                default:
                    break;
            }
            return (PartOfSpeech)0;
        }
    }
}
