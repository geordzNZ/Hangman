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
            Console.WriteLine($"Words in wordList: {wordsList.Count}");
            foreach (string word in wordsList) 
            {
                Console.WriteLine($" - {word}");
            }

            // Get word from wordList - randomly
            Random randomTargetID = new Random();
            int targetWordID = randomTargetID.Next(wordsList.Count);
            string targetWord = wordsList[targetWordID];

            Console.WriteLine($"\nID: {targetWordID} -- {targetWord}");
        }
    }
}