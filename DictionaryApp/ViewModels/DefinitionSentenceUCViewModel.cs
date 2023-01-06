using DictionaryApp.Commands;
using DictionaryApp.Helpers;
using DictionaryApp.Models;
using DictionaryApp.Views;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DictionaryApp.ViewModels
{
    public class DefinitionSentenceUCViewModel : BaseViewModel
    {
        public RelayCommand AddRemoveCommand { get; set; }

        public string Word { get; set; }

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

        private string imageSource = Constants.AddSignImageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        private string toolTipText = Constants.ToolTipTextAdd;

        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; OnPropertyChanged(); }
        }

        public PageItemModel model { get; set; }

        public string Text { get; set; } = string.Empty;

        public DefinitionSentenceUCViewModel()
        {
          

            AddRemoveCommand = new RelayCommand((a) =>
            {
                string example = string.Empty;
                if (SentenceExample.Contains("."))
                    example = "Sentence Example";
                else
                    example = "Example";


                if (ImageSource == Constants.AddSignImageSource)
                {
                    ImageSource = Constants.RemoveSignImageSource;
                    ToolTipText = Constants.ToolTipTextRemove;

                    model.Rank = ++App.WordCountInPage;

                    App.Page.AddParagraph(model);
                    App.AddedWords.Add(model);
                    App.Page.ScrollToEnd();
                }
                else
                {
                    var list = App.Page.Document.Blocks.Where(x => (x as Paragraph).Name != "DontDeleteBlock").ToList();

                    foreach (var item in list)
                    {
                        App.Page.Document.Blocks.Remove(item);
                    }

                    App.AddedWords.RemoveAll(x => x.Definition == model.Definition &&
                                                  x.SentenceExample == model.SentenceExample &&
                                                  x.Word == model.Word &&
                                                  x.Rank == model.Rank);
                    App.WordCountInPage = 0;

                    App.Page.AddWordsToView();

                    ImageSource = Constants.AddSignImageSource;
                    ToolTipText = Constants.ToolTipTextAdd;
                }
            });
        }

    }
}
