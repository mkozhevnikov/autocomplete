using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Engine.Kernel;
using Engine.Storage;
using Ninject;

namespace Engine
{
    public class PrefixReader {
        
        private readonly IPrefixStorage storage;

        private readonly TextReader reader;

        public PrefixReader(TextReader reader) {
            this.reader = reader;

            //получение экземляра класса, реализующего интерфейс IPrefixStorage
            storage = InjectContainer.Instance.Get<IPrefixStorage>();

            //чтение слов найденных в текстах
            var wordCount = Convert.ToInt32(reader.ReadLine());
            while (wordCount-- > 0) {
                storage.Add(reader.ReadLine());
            }
        }

        public static void Process(Stream input, Stream output) {
            new PrefixReader(new StreamReader(input)).Process(new StreamWriter(output));
        }

        public void Process(TextWriter writer) {
            //чтение слов, введенных пользователем
            var prefixCount = Convert.ToInt32(reader.ReadLine());
            while (prefixCount-- > 0) {
                //поиск слов, удовлетворяющих запросу
                var words = storage.Lookup(reader.ReadLine());
                foreach (var word in words) {
                    writer.WriteLine(word);
                }
                writer.WriteLine();
            }

            writer.Flush();
        }
    }
}
