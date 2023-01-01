using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.Models
{
    public class WordDetail
    {
        public string Word { get; set; }
        public string Phonetic { get; set; }
        public List<Phonetic> Phonetics { get; set; }
        public List<Meaning> Meanings { get; set; }
        public License License { get; set; }
        public List<string> SourceURLs { get; set; }
    }
}
