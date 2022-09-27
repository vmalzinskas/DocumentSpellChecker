using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentSpellChecker
{
    internal class Dict
    {
        private string _path = @"..\..\Dictionary\Dictionary.txt"; // location of dictionary text file;
        private string[] _dict; // array for storing strings from the dictionary text file;
        
        public Dict() 
        {
            CheckPath();
            OpenFile();
        }
        
        ///////////////////////
       
        public string[] Dictionary //  get the dictionary for use in comparison by SpellCk;
        {
            get => _dict;
        }


        public void CheckPath() // Gives a hint if the file is not found;
        {
            if(!File.Exists(_path))
            {
                Console.WriteLine("File not fount");
            }
        }
        public void OpenFile()
        { 
            _dict=File.ReadAllLines(_path); // reads all lines in text file to string array;
            Array.Sort(_dict); // resort just incase text file is disordered;
            _dict = Array.ConvertAll(_dict, word => word.ToLower()); // convert all to lower case
        }
        public void printTen() //for testing print first 10 words in array _dict;
        {
            for (int i=0;i < 10;i++)
            {
                Console.WriteLine(_dict[i]);
            }
        }
    }
}
