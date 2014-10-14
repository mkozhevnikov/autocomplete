using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Storage
{
    abstract class PrefixStorage : IPrefixStorage
    {
        public void Add(string word) {
            try {
                var wordAndRate = word.Split(' ');
                Add(wordAndRate[0], Convert.ToInt32(wordAndRate[1]));
            }
            catch (Exception e) {
                throw new Exception("Входная строка должна состоять из слова и числа, разделенных одним пробелом", e);
            }
        }

        protected abstract void Add(string word, int rate);

        public abstract string[] Lookup(string prefix, int count = 10);
    }
}
