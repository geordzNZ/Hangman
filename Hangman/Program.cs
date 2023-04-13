using System.Collections.Generic;

namespace Hangman
{
    internal class Program
    {
        // Word List
        //const List<string> WORDSLIST = new List<string>() { "Geordie", "Florian", "Michael", "Henrik" };
        const int MAX_GUESSES = 12;
        static void Main(string[] args)
        {
            // Header section
            Console.WriteLine("\t\t\tWELCOME");
            Console.WriteLine("\t\tHangman Word Guessing Game");
            Console.WriteLine("==========================================================\n");

            // Word List
            List<string> wordsList = new List<string>() { "Geordie", "Florian", "Michael", "Henrik" };

            // Get/store word from wordList - randomly
            Random randomTargetID = new Random();
            int targetWordID = randomTargetID.Next(wordsList.Count);
            string targetWord = wordsList[targetWordID].ToUpper();

            // Prefill output array
            char[] outputChars = new char[targetWord.Length];
            for (int i = 0; i < targetWord.Length; i++)
            {
                outputChars[i] = '_';
            }
            
            //Game Loop
            int wrongGuesses = 0;
            int totalCorrectGuesses = 0;
            do
            {
                // Get user input
                Console.Write($"\n\tPlease choose a letter: ");
                ConsoleKeyInfo guessedLetterInput = Console.ReadKey();
                char guessedLetter = char.Parse(guessedLetterInput.Key.ToString());

                int correctLetters = 0;
                for (int i = 0; i < targetWord.Length; i++)
                {
                    if (targetWord[i] == guessedLetter)
                    {
                        outputChars[i] = guessedLetter;
                        correctLetters++;
                    }
                }

                if (correctLetters != 0)
                {
                    totalCorrectGuesses += correctLetters;
                }
                else
                {
                    wrongGuesses++;
                }

                // Output results
                Console.WriteLine($"\n\tYou guessed: {guessedLetter} ... {correctLetters} in the word.");

                Thread.Sleep(3000);

                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tWELCOME");
                Console.WriteLine("\t\tHangman Word Guessing Game");
                Console.WriteLine("==========================================================\n");
                Console.WriteLine($"\t\t{String.Join(' ', outputChars)}");
                
                if (totalCorrectGuesses == targetWord.Length)
                {
                    Console.WriteLine($"\n\t\tYou guess correctly ... Well done!!\n");
                    System.Environment.Exit(0);
                }

            } while (wrongGuesses < MAX_GUESSES);

            Console.Clear();
            Console.WriteLine("\t\t\tWELCOME");
            Console.WriteLine("\t\tHangman Word Guessing Game");
            Console.WriteLine("==========================================================\n");
            Console.WriteLine($"\t\t{String.Join(' ',targetWord.ToCharArray())}");

            Console.WriteLine($"\n\t\tYou didnt guess correctly ... Better luck next time!!\n");

        }
    }
}