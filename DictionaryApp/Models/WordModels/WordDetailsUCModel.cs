using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using DictionaryApp.ViewModels;
using DictionaryApp.Helpers;
using System.Threading;

namespace DictionaryApp.Models.WordModels
{
    public class WordDetailsUCModel : BaseViewModel
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

        private bool isExpanded = true;

        public bool IsExpanded
        {
            get { return isExpanded; }
            set { isExpanded = value; OnPropertyChanged(); }
        }

        private string imageSource = Constants.CollapseArrowImageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        private SolidColorBrush color;

        public SolidColorBrush ScrollColor
        {
            get { return color; }
            set { color = value; OnPropertyChanged(); }
        }

        public WordDetailsUCModel(string word, string partOfSpeech)
        {
            ScrollColor = App.MyDictionary["SeventhColor"] as SolidColorBrush;
            PartOfSpeechImageSource = ImageHelpers.GetPartOfSpeechImageSource(partOfSpeech.ToPartOfSpeechEnum());
            partOfSpeech = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(partOfSpeech);
            word = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(word);
            Headline = $"{partOfSpeech} {Constants.Dot} {word}";
        }
    }
}
