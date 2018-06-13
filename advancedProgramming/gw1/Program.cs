using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ProjektZTP.gw1.Indicators;

namespace gw1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("mstall");
            FileInfo[] fi = di.GetFiles();
            Directory.CreateDirectory("data");
            Parallel.For(0, fi.Length, async i =>
            {
                IndicatorsService.Indicators ind = new IndicatorsService.Indicators();
                Dictionary<string, string> w = ind.Wskazniki(20, fi[i].FullName);

                await Writer.WriteAsyncToFile("data/" + fi[i].Name, w);
                foreach (var item in w)
                {
                    Console.WriteLine($"Data {item.Key} = {item.Value}");
                }
            });

            Console.Read();

        }
    }

    public class Writer
    {
        public static async Task WriteAsyncToFile(string path, Dictionary<string, string> data)
        {
            StreamWriter sww = new StreamWriter(path, false);
            foreach (var item in data)
            {
                await sww.WriteLineAsync($"Data {item.Key} = {item.Value}");
            }
            sww.Close();
        }
    }
    }
}