using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAnagram
{

    class AnagramCollection
    {
        public Dictionary<string, List<string>> Anagrams { get; private set; }

        
        public List<string> LongestAnagrams {get; private set;}
        public List<string> MostFrequentAnagramInIpnut { get; private set; }
        
        public AnagramCollection(List<string> inputWords)
        {
            this.Anagrams = GetAnagrams(inputWords);
            this.LongestAnagrams = new List<string>(Anagrams.Keys.Where(x => x.Length == Anagrams.Keys.Max(y => y.Length)));
            this.MostFrequentAnagramInIpnut = Anagrams.Values.Where(x => x.Count == Anagrams.Values.Max(y => y.Count)).ElementAt(0);
        }

        private Dictionary<string, List<string>> GetAnagrams(List<string> inputWords)
        {
            Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
            foreach (string word in inputWords)
            {
                string digest = orderStringAlphabetically(word);
                if (anagrams.ContainsKey(digest))
                {
                    anagrams[digest].Add(word);
                }
                else
                {
                    anagrams.Add(digest, new List<string> { word });
                }
            }
            return anagrams;
        }

        string orderStringAlphabetically(string input)
        {
            return new string(input.OrderBy(c => c).ToArray());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>()
            {
                "enlist", "skins", "inlets", "fresher", "boaters", "listen", "boaster", "silent", "borates", "tac", "refresh", "sinks", "knits", "stink", "sort", "cat", "rots"
            };

            var anagrams = new AnagramCollection(input);

            foreach (KeyValuePair<string, List<string>> anagramList in anagrams.Anagrams)
            {
                if(anagramList.Value.Count > 1)
                {
                    Console.WriteLine(anagramList.Key + ": " + String.Join(", ", anagramList.Value.ToArray()));
                }
            }

            Console.WriteLine("Longest Anagrams: " + String.Join(", ", anagrams.LongestAnagrams));
            Console.WriteLine("Anagram with the most words: " + String.Join(", ", anagrams.MostFrequentAnagramInIpnut));

            Console.ReadLine();
        }
    }
}