using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DocumentSpellChecker
{
    internal class TextBody
    {
        private string _text="";
        private List<string> _words = new List<string> ();

        public TextBody(){}
        public string Text
        { 
            set=>_text = value;
        }
        public List<string> Words // get the _words list for comparison by SpellCk
        {
            get => _words;
        }
        public void ListWords() // This should go through _text and build a word from the characters until it reaches an ' ' space charcater. Then add that word to the list _words;
        {
            string wordWorking = ""; //build a word from the characters in the the string _text; 

            // foreach (char letter in _text)
            char letter;
            for (int i=0; i<_text.Length; i++)
            {
                           
                letter = _text[i];                       
                if (Char.IsLetter(letter) || letter =='-' ) // find hypenanted words and words or 
                    wordWorking += letter;
                else if(!Char.IsLetter(letter)) 
                {
                    _words.Add(wordWorking);
                    wordWorking = "";
                }
            }
            _words.Add(wordWorking);
            wordWorking = "";
        }
        public void PrintList() // for debbuging-- make sure list _word is generated 
        {
            foreach (string word in _words)
            { 
                Console.WriteLine(word);
            }
        }
    }
}
