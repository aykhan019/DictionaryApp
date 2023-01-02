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
                    return @"\Assets\noun.png";
                case PartOfSpeech.Adverb:
                    return @"\Assets\adverb.png";
                case PartOfSpeech.Verb:
                    return @"\Assets\verb.png";
                case PartOfSpeech.Adjective:
                    return @"\Assets\adjective.png";
                case PartOfSpeech.Preposition:
                    return @"\Assets\preposition.png";
                case PartOfSpeech.Conjunction:
                    return @"\Assets\conjunction.png"; 
                case PartOfSpeech.Pronoun:
                    return @"\Assets\pronoun.png";
                case PartOfSpeech.Interjection:
                    return @"\Assets\interjection.png";
                default:
                    break;
            }
            return null;
        }
    }
}
