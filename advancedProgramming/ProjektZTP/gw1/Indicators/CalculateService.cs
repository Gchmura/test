using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProjektZTP.gw1.SignalsModel;

namespace ProjektZTP.gw1.Indicators
{
    public class CalculateService : ICalculateService
    {
        private readonly IIndicatorsService _indicatorsService;

        public CalculateService(IIndicatorsService indicatorsService)
        {
            _indicatorsService = indicatorsService;
        }

        public async Task<Dictionary<string, string>> Calculate(DirectoryInfo di)
        {


            FileInfo[] fi = di.GetFiles();
            var length = fi.Length;
            
            var firstPart = fi.Take(length / 4).ToArray();
            var secondPart =
                fi.Skip(length / 4).Take(length / 4).ToArray();
            var thirdPart =
                fi.Skip(length / 2).Take(length / 4).ToArray();
            var fourthPart =
                fi.Skip((length / 2) + (length / 4)).ToArray();


            var part1 = CalculatePart(firstPart);
            var part2 = CalculatePart(firstPart);
            var part3 = CalculatePart(firstPart);
            var part4 = CalculatePart(firstPart);


            //await Task.WhenAll(part1, part2, part3, part4);

            return new Dictionary<string, string>();
           
        }

        private  List<SignalDictionary> CalculatePart(FileInfo[] part)
        {
            List<SignalDictionary> signalList = new List<SignalDictionary>();

            Parallel.For(0, part.Length, i =>
            {
                Dictionary<string, string> w = _indicatorsService.Wskazniki(15, part[i].FullName);
                foreach (var item in w)
                {
                    
                    //Console.WriteLine($"Data {item.Key} = {item.Value}");
                    SignalDictionary signal = new SignalDictionary()
                    {
                        Key = item.Key,
                        Value = item.Value
                    };

                    signalList.Add(signal);
                }
            });

            return signalList;
        }

        
        public void CalculateNormal(DirectoryInfo di)
        {
            Dictionary<string,string> o = new Dictionary<string, string>();

            FileInfo[] fi = di.GetFiles();
            Parallel.For(0, fi.Length, i =>
            {

                Dictionary<string, string> w = _indicatorsService.Wskazniki(15, fi[i].FullName);

              
            
                foreach (var item in w)
                {
                    //do listy wypisywanie w textbloku
                    o.Add($"Data {item.Key} = {item.Value}", $"Data {item.Key} = {item.Value}");
                    //Console.WriteLine($"Data {item.Key} = {item.Value}");
                }
            });
            
        }

    }
}