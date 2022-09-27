using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; 

namespace DocumentSpellChecker
{
    internal class SpellCk
    { 
        private Counter _count = new Counter(); // a counter to keep track of number of words passed to Search
        List<string> spellingErrors = new List<string>(); // This list will we filled with the words not in the dictionary;
       
        public SpellCk()
        {
            _count.Reset(); // Clear the counter to zero for each spell check session.
        }

        public int Count // return the current count 
        {
            get => _count.Count;
        }
        public void Reset()
        {
            _count.Reset();
        }
        public List<string> TextCompare(List<string> words, string[] dict)
        {
            
            spellingErrors.Clear(); // make sure the list is empty;

            foreach (string word in words)
            {
                if (spellingErrors.Contains(word)) // make sure word is not place twice
                    continue;
                //  Console.Write(word+": "); // for testing so I can see the word that is correct of not;
                if (!Search(word.ToLower(), dict))  // if the word is incorrect add to list;
                {
                    
                    spellingErrors.Add(word);
                }
            }
            return spellingErrors;
        }
        public bool Search(string word, string[] dict) // Searches the array dict for the string word
        {
            

            if (Array.BinarySearch(dict, word) < 0) // no match returns a negative, a match returns the index of match
            {
               // Console.WriteLine("no match"); // for testing
                return false; // return false if  incorrect word
            }
            else 
            {
               // Console.WriteLine("correct"); // for testing
                return true; // return true if word is spelt correct
            }
        }
        public void Tick() 
        {
            _count.Increment();
        }
    }
}
