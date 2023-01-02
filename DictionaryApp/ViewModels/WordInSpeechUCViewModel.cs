using DictionaryApp.Helpers;
using DictionaryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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

		private string headline;

		public string Headline
        {
			get { return headline; }
			set { headline = value; OnPropertyChanged(); }
		}

		private ObservableCollection<UIElement> items = new ObservableCollection<UIElement>();

		public ObservableCollection<UIElement> Items
		{
			get { return items; }
			set { items = value; }
		}

		public WordInSpeechUCViewModel(WordDetail _wordDetail, Meaning meaning)
		{
            PartOfSpeechImageSource = ImageHelpers.GetPartOfSpeechImageSource(meaning.PartOfSpeech.ToPartOfSpeechEnum());
            WordDetail = _wordDetail;
			var partOfSpeech = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(meaning.PartOfSpeech); 
			var word = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(WordDetail.Word); 
            Headline = $"{partOfSpeech} {Constants.Dot} {word}";
        }
	}
}
