using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anagrams
{
    public class Word
    {
        public readonly string Original;
        public readonly int Length;
        public readonly int Crc;
        public readonly string Key;

        public Word(string original)
        {
            Original = original.ToLower();
            var letters = new HashSet<char>();
            Length = Original.Length;

            foreach (char letter in Original)
            {
                letters.Add(letter);
                Crc += letter.GetHashCode();
            }
            Key = GetKey(letters.ToList());
        }
        
        private string GetKey(List<char> letters)
        {
            var result = new StringBuilder();
            result.Append(Crc);
            result.Append("-");
            result.Append(Length);
            result.Append("-");
            letters.Sort();
            foreach (var letter in letters)
            {
                result.Append(letter);
            }
            return result.ToString();
        }
    }
}