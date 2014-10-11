using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Storage
{
    class DictionaryStorage : IPrefixStorage
    {
        private readonly Dictionary<string, int> storage = new Dictionary<string, int>();

        public void Add(string wordLine) {
            var wordAndRate = wordLine.Split(' ');
            storage.Add(wordAndRate[0], Convert.ToInt32(wordAndRate[1]));
        }

        public string[] Lookup(string prefix, int count = 10) {
            return storage.Where(pair => pair.Key.StartsWith(prefix))
                .OrderByDescending(pair => pair.Value)
                .ThenBy(pair => pair.Key)
                .Take(count)
                .Select(pair => pair.Key)
                .ToArray();
        }
    }
}
