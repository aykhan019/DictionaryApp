using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DictionaryApp.Helpers
{
    public class Constants
    {
        //public const string SearchDefaultText = "Search Word";
        public const string SearchDefaultText = "rise";

        public static string NoSentenceExample = "Sorry pal, we couldn't find sentence example for the word you were looking for.";

        public static string Dot = "•";
        public static string Dash = " - ";
        public static string Space = "  ";

        public static string CollapseArrowImageSource = @"\Assets\collapse.png";

        public static string ExpandArrowImageSource = @"\Assets\expand.png";

        public static string NounImageSource = @"\Assets\noun.png";
        public static string AdverbImageSource = @"\Assets\adverb.png";
        public static string VerbImageSource = @"\Assets\verb.png";
        public static string AdjectiveImageSource = @"\Assets\adjective.png";
        public static string PrepositionImageSource = @"\Assets\preposition.png";
        public static string ConjunctionImageSource = @"\Assets\conjunction.png";
        public static string PronounImageSource = @"\Assets\pronoun.png";
        public static string InterjectionImageSource = @"\Assets\interjection.png";

        public static string NoSynonyms = "No Synonyms";
        public static string NoAntonyms = "No Antonyms";

        public static string VocabularyHeadline = "Vocabulary";
        public static string VocabularyHeadlineFontFamily = "Algerian";

        public static string VocabularyMainFontFamily = "Segoe Print";
        public static FontWeight VocabularyDefinitionTextFontWeight = FontWeights.Bold;
        public static FontWeight VocabularySentenceExampleTextFontFamily = FontWeights.Light;

        public static int HeadlineFontSize = 30;
        public static int MainFontSize = 25;

        public static string AddSignImageSource = @"\Assets\addSign.png";
        public static string RemoveSignImageSource = @"\Assets\removeSign.png";

        public static string ToolTipTextRemove = "Remove Definition And Sentence Example From Dictionary";
        public static string ToolTipTextAdd = "Add Definition And Sentence Example To Dictionary";

        public static Brush WantedColor = Brushes.Green;
    }
}   
