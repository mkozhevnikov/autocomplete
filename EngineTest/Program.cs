using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Engine;

namespace EngineTest
{
    class Program
    {
        private static readonly string AssemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private static readonly string TestIn = AssemblyPath + @"\..\..\test.in";
        private static readonly string TestOut = AssemblyPath + @"\..\..\test.out";
        
        static void Main(string[] args)
        {
            var watcher = Stopwatch.StartNew();
            PrefixReader.Process(new FileStream(TestIn, FileMode.Open), new FileStream(TestOut, FileMode.Create));
            watcher.Stop();
            Console.WriteLine("Поиск слов в файле {0} занял {1}", Path.GetFullPath(TestIn), watcher.Elapsed);
        }
    }
}
