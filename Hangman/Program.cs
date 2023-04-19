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
        const string DIVIDER = "================================================================";
        const string BLANKER = "                                                                ";
        static void Main(string[] args)
        {
            // Word List
            List<string> wordsList = new List<string>() { "Geordie", "Florian", "Michael", "Henrik" };

            // Session Game Loop
            char playAgainAnswer = ' ';

            do
            {
                // Set up game
                Random randomTargetID = new Random();
                int targetWordID = randomTargetID.Next(wordsList.Count);
                string targetWord = wordsList[targetWordID].ToUpper();
                List<char> incorrectlyGuessedLetters = new List<char>();

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
                    // Header section
                    Console.Clear();
                    Console.WriteLine("\t\t\tWELCOME");
                    Console.WriteLine("\t\tHangman Word Guessing Game");
                    Console.WriteLine($"\t\tGuess in word in {MAX_GUESSES} guesses.");
                    Console.WriteLine($"{DIVIDER}\n");
                    Console.WriteLine($"\t\t{String.Join(' ', outputChars)}");
                    Console.WriteLine($"\n\tIncorrectly Guessed Letters: {String.Join(' ', incorrectlyGuessedLetters)} ... {MAX_GUESSES - wrongGuesses} left!");

                    // Get user input and validate 
                    char guessedLetter = ' ';
                    do
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.Write($"{BLANKER}");
                        Console.SetCursorPosition(0, 8);
                        Console.Write($"\tPlease enter a letter (A to Z): ");
                        ConsoleKeyInfo guessedLetterInput = Console.ReadKey();

                        if ((int)guessedLetterInput.Key >= 65 && (int)guessedLetterInput.Key <= 90) // Is letter
                        {
                            guessedLetter = char.Parse(guessedLetterInput.Key.ToString());
                            if (incorrectlyGuessedLetters.Contains(guessedLetter))
                            {
                                guessedLetter = ' ';
                            }
                        }

                        if (guessedLetter == ' ')
                        {
                            Console.Write($"\n\tNot a letter or you already tried that ... try again!!");
                            Thread.Sleep(750);
                            Console.SetCursorPosition(0, 9);
                            Console.Write($"{BLANKER}");
                        }

                    } while (guessedLetter == ' ');

                    // Check guessedLetter agaisnt Word
                    int correctLetters = 0;
                    for (int i = 0; i < targetWord.Length; i++)
                    {
                        if (targetWord[i] == guessedLetter)
                        {
                            outputChars[i] = guessedLetter;
                            correctLetters++;
                        }
                    }

                    // Accumulate stats, update wrong guesses list
                    if (correctLetters != 0)
                    {
                        totalCorrectGuesses += correctLetters;
                    }
                    else
                    {
                        incorrectlyGuessedLetters.Add(guessedLetter);
                        wrongGuesses++;
                    }

                    // Output result and pause for reading
                    Console.WriteLine($"\n\n\tYou guessed: {guessedLetter} ... {correctLetters} in the word.");
                    Thread.Sleep(1000);

                    // Exit if word is found
                    if (!outputChars.Contains('_'))
                    {
                        break;
                    }
                } while (wrongGuesses < MAX_GUESSES);

                // Game Outcome output section
                if (!outputChars.Contains('_'))
                {
                    // Output if Word guessed correctly
                    Console.SetCursorPosition(16, 5);
                    Console.Write($"{String.Join(' ', outputChars)}");

                    Console.SetCursorPosition(8, 14);
                    Console.WriteLine($"YOU GUESSED '{String.Join(' ', targetWord.ToCharArray())}' CORRECTLY ... WELL DONE!!\n");
                }
                else
                {
                    // Output if word not found and MAX_GUESSES reached
                    Console.SetCursorPosition(8, 14);
                    Console.WriteLine($"THE WORD WAS '{String.Join(' ', targetWord.ToCharArray())}' ... BETTER LUCK NEXT TIME!!\n");
                }

                Console.WriteLine($"{DIVIDER}\n");

                // Play again question and validation
                playAgainAnswer = ' ';
                do
                {
                    Console.SetCursorPosition(0, 18);
                    Console.Write($"{BLANKER}");
                    Console.SetCursorPosition(0, 18);
                    Console.Write($"\tWould you like to play again? (Y/N): ");
                    ConsoleKeyInfo playAgainInput = Console.ReadKey();

                    if ( (int)playAgainInput.Key == 78 || (int)playAgainInput.Key == 89) // N or Y
                    {
                        playAgainAnswer = char.Parse(playAgainInput.Key.ToString());
                    }

                    if (playAgainAnswer == ' ')
                    {
                        Console.Write($"\n\tPlease enter Y or N ... try again!!");
                        Thread.Sleep(750);
                        Console.SetCursorPosition(0, 19);
                        Console.Write($"{BLANKER}");
                    }
                } while (playAgainAnswer == ' ');

            } while (playAgainAnswer == 'Y');

            // Final closing output
            Console.WriteLine($"\n\n\tThanks for playing, see you real soon!!");
            Console.WriteLine($"{DIVIDER}\n");
        }
    }
}