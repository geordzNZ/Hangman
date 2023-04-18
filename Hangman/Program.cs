using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    internal class Program
    {
        // Word List
        //const List<string> WORDSLIST = new List<string>() { "Geordie", "Florian", "Michael", "Henrik" };

        //   _____
        //   |   |
        //   |   O
        //   |  _|_
        //   |   |
        //   |  / \
        //__/|\__
        const int MAX_GUESSES = 12;
        static void Main(string[] args)
        {
            // Word List
            List<string> wordsList = new List<string>() { "Geordie", "Florian", "Michael", "Henrik" };
            List<char> incorrectlyGuessedLetters = new List<char>();

            // Get/store word from wordList - randomly
            Random randomTargetID = new Random();
            int targetWordID = randomTargetID.Next(wordsList.Count);
            string targetWord = wordsList[targetWordID].ToUpper();

            // Prefill output array
            //char[] incorrectlyGuessedLetters = new char[26 - targetWord.Length];
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
                // Header section
                Console.Clear();
                Console.WriteLine("\t\t\tWELCOME");
                Console.WriteLine("\t\tHangman Word Guessing Game");
                Console.WriteLine("==========================================================\n");
                Console.WriteLine($"\t\t{String.Join(' ', outputChars)}");
                Console.WriteLine($"\n\tIncorrectly Guessed Letters: {String.Join(' ', incorrectlyGuessedLetters)} ");

                // Get user input
                char guessedLetter = ' ';
                do
                {
                    Console.Write($"\n\tPlease enter a letter (A to Z): ");
                    ConsoleKeyInfo guessedLetterInput = Console.ReadKey();

                    if ((int)guessedLetterInput.Key >= 65 && (int)guessedLetterInput.Key <= 90)
                    {
                        guessedLetter = char.Parse(guessedLetterInput.Key.ToString());
                        if (incorrectlyGuessedLetters.Contains(guessedLetter))
                        {
                            guessedLetter = ' ';
                        }
                    }
                } while (guessedLetter == ' ');

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
                    incorrectlyGuessedLetters.Add(guessedLetter);
                    wrongGuesses++;
                }

                // Output resultS
                Console.WriteLine($"\n\n\tYou guessed: {guessedLetter} ... {correctLetters} in the word.");

                Thread.Sleep(1000);

                // Exit if word is found
                if (!outputChars.Contains('_'))
                {
                    Console.SetCursorPosition(16, 4);
                    Console.Write($"{String.Join(' ', outputChars)}");

                    Console.SetCursorPosition(8, 13);
                    Console.WriteLine($"\n\n\tYOU GUESSED '{String.Join(' ', targetWord.ToCharArray())}' CORRECTLY ... WELL DONE!!\n");
                    Console.WriteLine("==========================================================\n");
                    return;
                }

            } while (wrongGuesses < MAX_GUESSES);

            // Output if word not found
            Console.SetCursorPosition(8, 13);
            Console.WriteLine($"\n\n\tTHE WORD WAS '{String.Join(' ', targetWord.ToCharArray())}' ... BETTER LUCK NEXT TIME!!\n");
            Console.WriteLine("==========================================================\n");
        }
    }
}