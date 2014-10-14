using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Storage
{
    class TrieStorage : PrefixStorage {
        
        /// <summary>
        /// Корень дерева
        /// </summary>
        private readonly TrieNode root = new TrieNode(' ');

        protected override void Add(string word, int rate) {
            var chars = word.ToCharArray();
            var currentNode = root;
            for (int idx = 0; idx < chars.Length; idx++) {
                //получаем дочерний узел или создаем его
                var letter = chars[idx];
                var child = currentNode[letter];
                if (child == null)
                    currentNode.Children.Add(child = new TrieNode(letter));

                //последнюю букву в слове заменяем листом
                if (idx == chars.Length - 1) {
                    var i = currentNode.Children.IndexOf(child);
                    currentNode.Children[i] = new TrieLeaf(child, word, rate);
                }

                //переходим к дочернему узлу
                currentNode = child;
            }
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

        /// <summary>
        /// Рекурсивный обход дерева для поиска слов
        /// </summary>
        /// <param name="node">Текущий узел дерева</param>
        /// <param name="prefix">Префикс слова</param>
        /// <param name="offset">Смещение в префиксе, соответствующее символу текущего узла</param>
        /// <returns>Листья, слова которых начинаются с префикса</returns>
        private IEnumerable<TrieLeaf> Lookup(TrieNode node, string prefix, int offset = 0) {
            if (offset != prefix.Length) {
                //переходим к поддереву, удовлетворяющему следующей части префикса
                node = node[prefix[offset]];
                if (node != null) {
                    foreach (var childNode in Lookup(node, prefix, offset + 1)) {
                        yield return childNode;
                    }
                }
            }
            else {
                //обходим дерево
                foreach (var child in node.Children) {
                    foreach (var childNode in Lookup(child, prefix, prefix.Length)) {
                        yield return childNode;
                    }
                }

                //возвращаем листья из поддерева
                if (node is TrieLeaf)
                    yield return node as TrieLeaf;
            }
        }
    }

    /// <summary>
    /// Класс, определяющий узел дерева
    /// </summary>
    internal class TrieNode {
        /// <summary>
        /// Потомки
        /// </summary>
        public List<TrieNode> Children { get; set; }

        /// <summary>
        /// Символ узла
        /// </summary>
        public char Letter { get; set; }
        
        public TrieNode(char letter) {
            Letter = letter;
            Children = new List<TrieNode>();
        }

        /// <summary>
        /// Потомок, соответствующий заданному символу
        /// </summary>
        /// <returns>Узел-потомок либо null, если такого узла нет</returns>
        public TrieNode this[char letter] {
            get {
                return Children.SingleOrDefault(node => node.Letter == letter);
            }
        }
    }

    /// <summary>
    /// Класс, определяющий лист дерева
    /// </summary>
    internal class TrieLeaf : TrieNode
    {
        /// <summary>
        /// Конструктор листа, копирующий свойства из узла
        /// </summary>
        /// <param name="node">Узел, который преобразуется в лист</param>
        /// <param name="word">Слово целиком, соответствующее листу</param>
        /// <param name="rate">Частота появления слова в тексте</param>
        public TrieLeaf(TrieNode node, string word, int rate) : base(node.Letter) {
            Children = node.Children;
            Word = word;
            Rate = rate;
        }

        /// <summary>
        /// Слово целиком
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// Частота появления слова в тексте
        /// </summary>
        public int Rate { get; set; }
    }
}
