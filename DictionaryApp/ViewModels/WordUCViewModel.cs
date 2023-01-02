using DictionaryApp.Commands;
using DictionaryApp.Helpers;
using DictionaryApp.Models;
using DictionaryApp.Models.WordModels;
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

		private WordDetailModel wordDetailModel;

		public WordDetailModel WordDetailModel
        {
			get { return wordDetailModel; }
			set { wordDetailModel = value; }
		}

		public WordUCViewModel(WordDetail _wordDetail)
		{
            WordDetailModel = new WordDetailModel(_wordDetail);

            ListenPronunciationCommand = new RelayCommand((l) =>
			{
                using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Female);
                    synthesizer.SetOutputToDefaultAudioDevice();
                    synthesizer.Speak(WordDetailModel.WordDetail.Word);
                }
			});
        }
	}
}
