namespace anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"C:\Users\l.dutrillaux\Documents\Kata\Anagrams\wordlist.txt";

            var anagrammer = new Anagramer();

            anagrammer.PrintAnagrams(fileName);

        }
    }
}
