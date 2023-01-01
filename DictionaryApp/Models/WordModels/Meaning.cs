using System.Collections.Generic;

namespace DictionaryApp.Models
{
    public class Meaning
    {
        public string PartOfSpeech { get; set; }
        public List<DefinitionOfWord> Definitions { get; set; }
        public List<string> Synonyms { get; set; }
        public List<string> Antonyms { get; set; }
    }
}