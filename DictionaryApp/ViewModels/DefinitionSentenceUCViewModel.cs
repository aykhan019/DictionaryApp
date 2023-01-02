using DictionaryApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.ViewModels
{
    public class DefinitionSentenceUCViewModel : BaseViewModel
    {
		private string definition;

		public string Definition
        {
			get { return definition; }
			set { definition = value; OnPropertyChanged(); }
		}

		private string sentenceExample;

		public string SentenceExample	
        {
			get { return sentenceExample; }
			set { sentenceExample = value; OnPropertyChanged(); }
		}
	}
}
