using DictionaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.ViewModels
{
    public class WordInSpeechUCViewModel : BaseViewModel
    {
		private string partOfSpeechImageSource;

		public string PartOfSpeechImageSource
        {
			get { return partOfSpeechImageSource; }
			set { partOfSpeechImageSource = value; OnPropertyChanged(); }
		}

		private WordDetail wordDetail;

		public WordDetail WordDetail
        {
			get { return wordDetail; }
			set { wordDetail = value; }
		}

		public WordInSpeechUCViewModel()
		{

		}
	}
}
