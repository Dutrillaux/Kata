using System.Collections.Generic;
using System.Text;

namespace anagrams
{
    public class WordSorted
    {
        public bool HasMoreThanOneItem;

        public List<Word> Words = new List<Word>();

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var word in Words)
            {
                result.Append(word.Original).Append(" ");
            }

            return result.ToString().TrimEnd();
        }
    }
}