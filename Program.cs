using System;

namespace GuessingGame
{
    class Program
    {
        static void Main()
        {
            var rand = new Random();
            int secretNumber = rand.Next(1, 101);
            Console.WriteLine(secretNumber);
            int parsedResponse;
            int numberOfGuesses = 0;

            Console.WriteLine("Try to guess the secret number! (1-100)");
            while (numberOfGuesses <= 3)
            {
                Console.Write("What's your guess? ");
                string response = Console.ReadLine();

                bool successfulParse = Int32.TryParse(response, out parsedResponse);
                if (successfulParse)
                {
                    if (parsedResponse == secretNumber)
                    {
                        Console.WriteLine("You guessed the right number!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No luck!");
                        numberOfGuesses++;
                        if (numberOfGuesses == 4)
                        {
                            Console.WriteLine("You're all out of guesses!");
                        }
                        else
                        {
                            Console.WriteLine($"Guesses Remaining: ({4 - numberOfGuesses})");
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    numberOfGuesses++;
                    Console.WriteLine("That is not a number! Try again!");
                    Console.WriteLine($"Guesses Remaining: ({4 - numberOfGuesses})");
                    Console.WriteLine();
                }
            }
        }
    }
}
