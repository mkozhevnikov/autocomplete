using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Storage
{
    class CacheTrieStorage : TrieStorage
    {
        private readonly Dictionary<string, string[]> cache = new Dictionary<string, string[]>();

        public override string[] Lookup(string prefix, int count = 10) {
            if (cache.ContainsKey(prefix))
                return cache[prefix];
            var result = base.Lookup(prefix, count);
            cache.Add(prefix, result);
            return result;
        }
    }
}
