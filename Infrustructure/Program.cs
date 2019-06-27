
using System;
using System.Diagnostics;
using System.IO;

namespace Infrustructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\filr.txt";
            var readlines = File.ReadAllLines(path);
            using (StreamWriter sw = new StreamWriter("D:\\output.txt"))
            {
                foreach (var line in readlines)
                {
                    Console.WriteLine(line);
                    string linet = line.Replace("\t", " ");
                    sw.WriteLine(linet);
                }
            }
            Console.ReadKey();

        }
    }
}
