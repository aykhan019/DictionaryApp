using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.Helpers
{
    public class ImageHelpers
    {
        public static string GetPartOfSpeechImageSource(PartOfSpeech en)
        {
            switch (en)
            {
                case PartOfSpeech.Noun:
                    return Constants.NounImageSource;
                case PartOfSpeech.Adverb:
                    return Constants.AdverbImageSource;
                case PartOfSpeech.Verb:
                    return Constants.VerbImageSource;
                case PartOfSpeech.Adjective:
                    return Constants.AdjectiveImageSource;
                case PartOfSpeech.Preposition:
                    return Constants.PrepositionImageSource;
                case PartOfSpeech.Conjunction:
                    return Constants.ConjunctionImageSource;
                case PartOfSpeech.Pronoun:
                    return Constants.PronounImageSource;
                case PartOfSpeech.Interjection:
                    return Constants.InterjectionImageSource;
                default:
                    break;
            }
            return null;
        }
    }
}
