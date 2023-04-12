using System.Collections.Generic;

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

            // Get/store word from wordList - randomly
            Random randomTargetID = new Random();
            int targetWordID = 0;
            //int targetWordID = randomTargetID.Next(wordsList.Count);
            string targetWord = wordsList[targetWordID].ToUpper();
            List<char> outputList = new List<char>();

            Console.WriteLine($"\nID: {targetWordID} --> {targetWord}");

            // Get user input
            Console.Write($"\n\tPlease choose a letter: ");
            string guessedLetterInput = Console.ReadLine().ToUpper();
            char guessedLetter = char.Parse(guessedLetterInput);

            Console.WriteLine($"Letter guessed is: {guessedLetter}");

            // Check if letter is in word
            //foreach (char letter in targetWord)
            //{
            //    Console.WriteLine($" - {letter} --> {letter == guessedLetter}");
            //}
            for (int i = 0; i < targetWord.Length; i++)
            {
                Console.WriteLine($" - {targetWord[i]} --> {targetWord[i] == guessedLetter}");
                if (targetWord[i] == guessedLetter)
                {
                    outputList.Add(guessedLetter);
                }
                else
                {
                    outputList.Add('_');
                }

                // Output results
                Console.WriteLine(String.Join(" ", outputList));
            }

        }
    }
}