using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSpellChecker
{
    internal class Counter
    {
        private int _count; // current word index in text to be checked.

        public Counter()
        {
            _count = 0;
        }
        public int Count
        {
            get => _count;
        }
        public void Increment()
        {
            _count++;
        }
        public void Reset()
        {
            _count = 0;
        }
    }
}
