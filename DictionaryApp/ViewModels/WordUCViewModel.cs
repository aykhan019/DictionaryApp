using DictionaryApp.Commands;
using DictionaryApp.Helpers;
using DictionaryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.ViewModels
{
    public class WordUCViewModel : BaseViewModel
    {
		public RelayCommand ListenPronunciationCommand { get; set; }

        private WordDetail wordDetail;

		public WordDetail WordDetail
        {
			get { return wordDetail; }
			set { wordDetail = value; OnPropertyChanged(); }
		}

		private string phonetic;

		public string Phonetic
        {
			get { return phonetic; }
			set { phonetic = value; OnPropertyChanged(); }
		}

		private ObservableCollection<string> pronunciationTypes = new ObservableCollection<string>();

		public ObservableCollection<string> PronunciationTypes
        {
			get { return pronunciationTypes; }
			set { pronunciationTypes = value; OnPropertyChanged(); }
		}

        private ObservableCollection<string> pronunciationUrls = new ObservableCollection<string>();

        public ObservableCollection<string> PronunciationUrls
        {
            get { return pronunciationUrls; }
            set { pronunciationUrls = value; OnPropertyChanged(); }
        }

        private int selectedIndex;
				
		public int SelectedIndex
        {
			get { return selectedIndex; }
			set { selectedIndex = value; OnPropertyChanged(); }
		}

		public WordUCViewModel(WordDetail _wordDetail)
		{
			WordDetail= _wordDetail;
			Phonetic = $"[  {WordDetail.Phonetic}  ]";

			foreach (var pr in WordDetail.Phonetics)
			{
				var url = pr.SourceURL;
                if (!string.IsNullOrEmpty(url))
				{
					PronunciationUrls.Add(url);
					PronunciationTypes.Add(url.Substring(url.Length - 6, 2));
                }
			}

            ListenPronunciationCommand = new RelayCommand((l) =>
			{
                using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.SetOutputToDefaultAudioDevice();
                    // Speaks a string synchronously. 
                    synthesizer.Speak(WordDetail.Word);
                }
			});
        }
	}
}
