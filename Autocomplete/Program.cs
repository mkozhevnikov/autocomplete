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
            new PrefixReader(Console.In).Process(Console.Out);
        }
    }
}
