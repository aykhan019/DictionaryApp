using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.Models
{
    public class PageItemModel
    {
        public int Rank { get; set; }
        public string Word { get; set; }
        public string Definition { get; set; }
        public string SentenceExample { get; set; }
    }
}
