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

        private WordUCModel wordUCModel;

        public WordUCModel WordUCModel
        {
            get { return wordUCModel; }
            set { wordUCModel = value; }
        }

        public WordUCViewModel(WordDetail _wordDetail)
        {
            WordUCModel = new WordUCModel(_wordDetail);
            WordUCModel.Word = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(WordUCModel.WordDetail.Word);

            ListenPronunciationCommand = new RelayCommand((l) =>
            {
                Thread t = new Thread(() =>
                {
                    using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                    {
                        synthesizer.SelectVoiceByHints(VoiceGender.Female);
                        synthesizer.SetOutputToDefaultAudioDevice();
                        synthesizer.Speak(WordUCModel.WordDetail.Word);
                    }
                }); t.Start();
            });
        }
    }
}
