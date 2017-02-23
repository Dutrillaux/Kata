using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace anagrams
{
    public interface IAnagramer
    {
        void PrintAnagrams(string fullPathfileName);
    }

    public class Anagramer
    {
        public IEnumerable<string> GetAnagrams(IEnumerable<Word> words)
        {
            var anagrams = PreTraitement(words);

            return AnagramsToList(anagrams);
        }

        private IEnumerable<string> AnagramsToList(Dictionary<string, WordSorted> anagrams)
        {
            return anagrams.Where(x => x.Value.HasMoreThanOneItem).Select(wordSorted => wordSorted.Value.ToString());
        }

        private Dictionary<string, WordSorted> PreTraitement(IEnumerable<Word> words)
        {
            var result = new Dictionary<string, WordSorted>();
            foreach (var word in words)
            {
                WordSorted wordSorted;
                if (!result.TryGetValue(word.Key, out wordSorted))
                {
                    wordSorted = new WordSorted();
                    result[word.Key] = wordSorted;
                }
                else
                {
                    wordSorted.HasMoreThanOneItem = true;
                }
                wordSorted.Words.Add(word);

            }
            return result;
        }

        public IEnumerable<Word> GetWords(IEnumerable<string> words)
        {
            return words.Select(word => new Word(word));
        }

        public IEnumerable<string> ReadFromFile(string fullPathfileName)
        {
            string line;

            using (var file = new StreamReader(fullPathfileName))
                while ((line = file.ReadLine()) != null)
                {

                    yield return line;
                }
        }

        public IEnumerable<string> GetAnagramsFromFile(string fullPathfileName)
        {
            var words = GetWordsFromfile(fullPathfileName);

            return GetAnagrams(words);
        }

        private IEnumerable<Word> GetWordsFromfile(string fullPathfileName)
        {
            var rawWords = ReadFromFile(fullPathfileName);

            var words = GetWords(rawWords);
            return words;
        }

        public void PrintAnagrams(string fullPathfileName)
        {
            var stopwatch = Stopwatch.StartNew();

            var anagramsFromFile = GetAnagramsFromFile(fullPathfileName);

            stopwatch.Stop();
            
            foreach (var anagramsline in anagramsFromFile)
            {
                Console.WriteLine(anagramsline);
            }
            Console.WriteLine("time to calculate : " + stopwatch.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }
    }
}