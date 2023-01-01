using System.Collections.Generic;

namespace DictionaryApp.Models
{
    public class DefinitionOfWord
    {
        public string Definition { get; set; }
        public List<string> Synonyms { get; set; }
        public List<string> Antonyms { get; set; }
        public string Example { get; set; }
    }
}   