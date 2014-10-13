﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Engine.Kernel;
using Engine.Storage;
using Ninject;

namespace Engine
{
    public class PrefixReader
    {
        public static void Process(Stream input, Stream output) {
            Process(new StreamReader(input), new StreamWriter(output));
        }

        public static void Process(TextReader reader, TextWriter writer) {
            //получение экземляра класса, реализующего интерфейс IPrefixStorage
            var storage = InjectContainer.Instance.Get<IPrefixStorage>();

            //чтение слов найденных в текстах
            var wordCount = Convert.ToInt32(reader.ReadLine());
            while (wordCount-- > 0)
            {
                storage.Add(reader.ReadLine());
            }

            //чтение слов, введенных пользователем
            var prefixCount = Convert.ToInt32(reader.ReadLine());
            while (prefixCount-- > 0)
            {
                //поиск слов, удовлетворяющих запросу
                var words = storage.Lookup(reader.ReadLine());
                foreach (var word in words)
                {
                    writer.WriteLine(word);
                }
                writer.WriteLine();
            }

            writer.Flush();
        }
    }
}
