using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Storage
{
    abstract class PrefixStorage : IPrefixStorage
    {
        public void Add(string word) {
            var wordAndRate = word.Split(' ');
            Add(wordAndRate[0], Convert.ToInt32(wordAndRate[1]));
        }

        protected abstract void Add(string word, int rate);

        public abstract string[] Lookup(string prefix, int count = 10);
    }
}
