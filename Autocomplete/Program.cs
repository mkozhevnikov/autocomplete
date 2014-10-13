using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine;

namespace Autocomplete
{
    class Program
    {
        static void Main(string[] args)
        {
            PrefixReader.Process(Console.In, Console.Out);
        }
    }
}
