using System.ComponentModel;

namespace DictionaryApp.Models
{
    public class Phonetic
    {
        public string Text { get; set; }
        public string Audio { get; set; }
        public string SourceURL { get; set; }
        public License License { get; set; }
    }
}