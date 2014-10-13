using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Storage
{
    class TrieStorage : PrefixStorage {
        
        private readonly TrieNode root = new TrieNode(' ');

        protected override void Add(string word, int rate) {
            var chars = word.ToCharArray();
            var currentNode = root;
            foreach (var letter in chars) {
                var child = currentNode[letter];
                if (child == null)
                    currentNode.Children.Add(child = new TrieNode(letter));
                currentNode = child;
            }
            currentNode.Rate = rate;
            currentNode.IsLeaf = true;
        }

        public override string[] Lookup(string prefix, int count = 10) {
            return
                Lookup(root, prefix)
                    .OrderByDescending(node => node.Rate)
                    .ThenBy(node => node.Word)
                    .Take(count)
                    .Select(node => node.Word)
                    .ToArray();
        }

        private IEnumerable<TrieNode> Lookup(TrieNode node, string prefix, string word = "") {
            if (prefix.Length == 0) {
                foreach (var child in node.Children) {
                    foreach (var childNode in Lookup(child, prefix, word + child.Letter)) {
                        yield return childNode;
                    }
                }

                if (node.IsLeaf) {
                    node.Word = word;
                    yield return node;
                }
            }
            else {
                node = node[prefix[0]];
                if (node != null) {
                    foreach (var childNode in Lookup(node, prefix.Substring(1), word + node.Letter)) {
                        yield return childNode;
                    }
                }
            }
        }
    }

    class TrieNode {
        public List<TrieNode> Children { get; set; }

        public char Letter { get; set; }

        public int Rate { get; set; }

        public bool IsLeaf { get; set; }

        public string Word { get; set; }
        
        public TrieNode(char letter) {
            Letter = letter;
            Children = new List<TrieNode>();
        }

        public TrieNode this[char letter] {
            get {
                return Children.SingleOrDefault(node => node.Letter == letter);
            }
        }
    }
}
