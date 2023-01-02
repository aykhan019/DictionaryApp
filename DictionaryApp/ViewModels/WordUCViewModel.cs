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
using System.Threading;
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

		private string partOfSpeechAndDefinition;

		public string PartOfSpeechAndDefinition
        {
			get { return partOfSpeechAndDefinition; }
			set { partOfSpeechAndDefinition = value; OnPropertyChanged(); }
		}

		private string sentenceExample;

		public string SentenceExample
		{
			get { return sentenceExample; }
			set { sentenceExample = value; OnPropertyChanged(); }
		}



		public WordUCViewModel(WordDetail _wordDetail)
		{
			WordDetail= _wordDetail;
			Phonetic = $"[  {WordDetail.Phonetic}  ]";
			var firstMeaning = WordDetail.Meanings[0];
            PartOfSpeechAndDefinition = firstMeaning.PartOfSpeech + " ~ " + firstMeaning.Definitions[0].Definition;
            PartOfSpeechAndDefinition = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(PartOfSpeechAndDefinition);
            SentenceExample = WordDetail.Meanings[0].Definitions[0].Example;
			if (SentenceExample == null || SentenceExample.Trim().Length == 0)
            {
				SentenceExample = Constants.NoDefinition;
			}


            ListenPronunciationCommand = new RelayCommand((l) =>
			{
                using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Female);
                    synthesizer.SetOutputToDefaultAudioDevice();
                    // Speaks a string synchronously. 
                    synthesizer.Speak(WordDetail.Word);
                }
			});
        }
	}
}
