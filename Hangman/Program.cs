namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Header section
            Console.Clear();
            Console.WriteLine("\t\t\tWELCOME");
            Console.WriteLine("\t\tHangman Word Guessing Game");

            Console.WriteLine("==========================================================\n");

            // Word List
            List<string> wordsList = new List<string>() { "Geordie", "Florian", "Michael", "Henrik" };

            // Check List populated correctly
            foreach (string word in wordsList) 
            {
                Console.WriteLine($"{word}");
            }
        }
    }
}