using DictionaryApp.Helpers;
using DictionaryApp.Models;
using DictionaryApp.Views;
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
    public class WordDetailsUCViewModel : BaseViewModel
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

		private ObservableCollection<UIElement> synonyms = new ObservableCollection<UIElement>();

		public ObservableCollection<UIElement> Synonyms
        {
			get { return synonyms; }
			set { synonyms = value; OnPropertyChanged(); }
		}
        
        private ObservableCollection<UIElement> antonyms = new ObservableCollection<UIElement>();

		public ObservableCollection<UIElement> Antonyms
        {
			get { return antonyms; }
			set { antonyms = value; OnPropertyChanged(); }
		}

		public WordDetailsUCViewModel(WordDetail _wordDetail, Meaning meaning)
		{
            PartOfSpeechImageSource = ImageHelpers.GetPartOfSpeechImageSource(meaning.PartOfSpeech.ToPartOfSpeechEnum());
            WordDetail = _wordDetail;
			var partOfSpeech = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(meaning.PartOfSpeech); 
			var word = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(WordDetail.Word); 
            Headline = $"{partOfSpeech} {Constants.Dot} {word}";

			AddSynonymsToView();
            AddAntonymsToView();
        }

        private void AddSynonymsToView()
        {
            Synonyms.Clear();
            var synonyms = WordDetailHelpers.GetSynonymsOfWord(WordDetail);
            foreach (var synonym in synonyms)
            {
                var textUC = new TextUC();
                var textUCVM = new TextUCViewModel(synonym);
                textUC.DataContext = textUCVM;
                Synonyms.Add(textUC);
            }
        }

        private void AddAntonymsToView()
        {
            Antonyms.Clear();
            var antonyms = WordDetailHelpers.GetAntonymsOfWord(WordDetail);
            foreach (var antonym in antonyms)
            {
                var textUC = new TextUC();
                var textUCVM = new TextUCViewModel(antonym);
                textUC.DataContext = textUCVM;
                Antonyms.Add(textUC);
            }
        }
    }
}
