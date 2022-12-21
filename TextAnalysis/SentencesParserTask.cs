using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentenceSeparator = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            var sb = new StringBuilder();
            foreach (string sentence in text.ToLower().Split(sentenceSeparator))
            {
                if (String.IsNullOrWhiteSpace(sentence))
                    ; //skip empry senteces 
                else if (ReturnListWords(sentence, sb).Count > 0)
                    sentencesList.Add(ReturnListWords(sentence, sb));
            }
            return sentencesList;
        }

        public static List<string> ReturnListWords(string sentence, StringBuilder sb)
        {
            var listWords = new List<string>();
            sb.Clear();
            sb.Append(sentence);
            foreach (string word in RemoveOtherSeparators(sb).Split(new string[] { " ", "\r", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries))
                listWords.Add(word.Trim(' '));
            return listWords;
        }

        public static string RemoveOtherSeparators(StringBuilder sb)
        {
            foreach (var literal in sb.ToString())
            {
                if (char.IsLetter(literal) || literal == '\'' || Char.IsWhiteSpace(literal))
                    ;
                else
                    sb.Replace(literal, ' ');
            }
            return sb.ToString();
        }
    }
}