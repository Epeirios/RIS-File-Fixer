using Google.Cloud.Language.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class GoogleApi
    {
        public GoogleApi()
        {

        }

        public List<string[]> DoAnalysis(string text)
        {
            var client = LanguageServiceClient.Create();

            AnalyzeSyntaxResponse syntaxResponse = client.AnalyzeSyntax(new Document()
            {
                Content = text,
                Type = Document.Types.Type.PlainText
            });

            var syntaxSenstiment = syntaxResponse.Tokens;
            List<string[]> keywords = ExtractNounsWithAdj(syntaxSenstiment);

            return keywords;
        }

        private List<string[]> ExtractNouns(Google.Protobuf.Collections.RepeatedField<Token> syntaxSenstiment)
        {
            List<string[]> keywords = new List<string[]>();

            foreach (var token in syntaxSenstiment)
            {
                if (token.PartOfSpeech.Tag == PartOfSpeech.Types.Tag.Noun)
                {
                    keywords.Add(new string[] { "KW", token.Lemma });
                }
            }

            return keywords;
        }

        private List<string[]> ExtractNounsWithAdj(Google.Protobuf.Collections.RepeatedField<Token> syntaxSenstiment)
        {
            List<string[]> keywords = new List<string[]>();

            for (int i = 0; i < syntaxSenstiment.Count; i++)
            {
                string lemma = string.Empty;
                string templemma = string.Empty;

                switch (syntaxSenstiment[i].PartOfSpeech.Tag)
                {
                    case PartOfSpeech.Types.Tag.Noun:
                        if (templemma != string.Empty)
                        {
                            lemma = templemma + syntaxSenstiment[i];
                            templemma = string.Empty;
                        }
                        break;
                    case PartOfSpeech.Types.Tag.Adj:
                        templemma = syntaxSenstiment[i].Lemma + " ";
                        break;
                    default:
                        break;
                }

                if (syntaxSenstiment[i].PartOfSpeech.Tag == PartOfSpeech.Types.Tag.Noun)
                {
                    string lemma = "";
                    if (i >= 1)
                    {
                        if (syntaxSenstiment[i - 1].PartOfSpeech.Tag == PartOfSpeech.Types.Tag.Adj || syntaxSenstiment[i - 1].PartOfSpeech.Tag == PartOfSpeech.Types.Tag.Noun)
                        {
                            if (i >= 2)
                            {
                                if (syntaxSenstiment[i - 2].PartOfSpeech.Tag == PartOfSpeech.Types.Tag.Adj || syntaxSenstiment[i - 2].PartOfSpeech.Tag == PartOfSpeech.Types.Tag.Noun)
                                {
                                    lemma += syntaxSenstiment[i - 2].Lemma + " ";
                                }
                            }

                            lemma += syntaxSenstiment[i - 1].Lemma + " ";
                        }
                    }

                    lemma += syntaxSenstiment[i].Lemma;

                    keywords.Add(new string[] { "KW", lemma });
                }
            }

            return keywords;
        }
    }
}
