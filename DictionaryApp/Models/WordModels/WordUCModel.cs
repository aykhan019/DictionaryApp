using DictionaryApp.Helpers;
using DictionaryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DictionaryApp.Models.WordModels
{
    public class WordUCModel : BaseViewModel
    {
        private string word;

        public string Word
        {
            get { return word; }
            set { word = value; OnPropertyChanged(); }
        }

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

        public WordUCModel(WordDetail _wordDetail)
        {
            WordDetail = _wordDetail;
            Phonetic = $"[  {WordDetail.Phonetic}  ]";
            if (Phonetic.Trim().Length == 0)
            {
                Phonetic = WordDetail.Phonetics.Where(p => p.Text.Trim().Length != 0).First().Text;
            }
            var firstMeaning = WordDetail.Meanings[0];
            var partOfSpeech = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(firstMeaning.PartOfSpeech);
            PartOfSpeechAndDefinition = $"{partOfSpeech} ~ \"{firstMeaning.Definitions[0].Definition}\"";
            SentenceExample = WordDetail.Meanings[0].Definitions[0].Example;
            if (SentenceExample == null || SentenceExample.Trim().Length == 0)
                SentenceExample = Constants.NoSentenceExample;
            else
                SentenceExample = $"\"{SentenceExample}\"";
        }
    }
}
