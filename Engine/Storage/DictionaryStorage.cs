using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Storage
{
    class DictionaryStorage : PrefixStorage
    {
        private readonly Dictionary<string, int> storage = new Dictionary<string, int>();

        protected override void Add(string word, int rate) {
            storage.Add(word, rate);
        }

        public override string[] Lookup(string prefix, int count = 10) {
            return storage.Where(pair => pair.Key.StartsWith(prefix))
                .OrderByDescending(pair => pair.Value)
                .ThenBy(pair => pair.Key)
                .Take(count)
                .Select(pair => pair.Key)
                .ToArray();
        }
    }
}
