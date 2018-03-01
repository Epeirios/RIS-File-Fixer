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
                Type = Document.Types.Type.PlainText,
                Language = "en"
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

            string lemma = string.Empty;
            string templemma = string.Empty;

            for (int i = 0; i < syntaxSenstiment.Count; i++)
            {
                switch (syntaxSenstiment[i].PartOfSpeech.Tag)
                {
                    case PartOfSpeech.Types.Tag.Noun:
                        if (templemma != string.Empty)
                        {
                            lemma += templemma + syntaxSenstiment[i].Lemma;
                            templemma = string.Empty;
                        }
                        else
                        {
                            if (lemma != string.Empty)
                            {
                                lemma += " ";
                            }
                            lemma += syntaxSenstiment[i].Lemma;
                        }
                        break;
                    case PartOfSpeech.Types.Tag.Adj:
                        templemma += syntaxSenstiment[i].Lemma + " ";
                        break;
                    default:
                        if (lemma != string.Empty)
                        {
                            keywords.Add(new string[] { "KW", lemma });

                            lemma = string.Empty;
                            templemma = string.Empty;
                        }

                        break;
                }
            }

            return keywords;
        }
    }
}
