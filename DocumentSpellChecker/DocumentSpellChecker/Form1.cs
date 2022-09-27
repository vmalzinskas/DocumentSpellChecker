using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DocumentSpellChecker
{
    public partial class Form1 : Form
    {
        Dict myDictionary = new Dict();
        TextBody myText = new TextBody();
        SpellCk mySpellCk = new SpellCk();
        List<string> _spellingErrors = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // inputText is the name of the RichTextBox
        {
            inputText.SelectAll(); // clear the background color to make sure corrected misstake don't remain red;
            inputText.SelectionBackColor = Color.White;
            inputText.DeselectAll();

            myText.Text = inputText.Text; // Add the text in the text box to the string variable in TextBody to be converted to a list<string>;
            myText.ListWords(); // Convert continous string into the list in myText;
            _spellingErrors = mySpellCk.TextCompare(myText.Words, myDictionary.Dictionary);   //compare each word in TextBody list to the dictionary;

            mySpellCk.Reset(); //clear the error count;
            foreach (string misSpelled in _spellingErrors)
            {
                int wordStartIndex = 0;
                string pattern = @"([^a-zA-z]|\^|_)";      // This pattern is added to the begining and end of the word to avoid incorrectly highlightng
                pattern += misSpelled + pattern;    // previously found erros that appear inside correct larger words. ie "ook" is and error but not in "book"
                Regex rx = new Regex(pattern);

                Console.WriteLine(misSpelled);
                foreach (Match match in rx.Matches(inputText.Text))
                {
                    mySpellCk.Tick();
                    wordStartIndex = match.Index+1;
                    inputText.SelectionStart = wordStartIndex; // select word from wordindext to wordindext + length and color red                                                             
                    inputText.SelectionLength = misSpelled.Length;
                    inputText.SelectionBackColor = Color.Red;
                    inputText.DeselectAll();
                }

                ErrorTxtBox.Text = mySpellCk.Count.ToString();


            }
        }
    }
}
