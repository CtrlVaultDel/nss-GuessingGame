using System;

namespace GuessingGame
{
    class Program
    {
        static void Main()
        {
            // Create a secret random number
            var rand = new Random();
            int secretNumber = rand.Next(1, 101);

            // Variables for the difficulty to be chosen later
            int tempDifficulty;
            int parsedDifficulty = 0;

            // Variable that will hold user guesses
            int parsedResponse;

            // Variable that will hold the amount of times the user has guessed
            int numberOfGuesses = 0;

            // Variable that will dictate how many times the user can guess before
            // a game over. Determined by the difficulty level the user choses.
            int allowedGuesses = 0;

            while (parsedDifficulty == 0)
            {
                // Display difficulty levels
                Console.WriteLine("Choose a difficulty:");
                Console.WriteLine("[1] Cheater (Unlimited Guesses");
                Console.WriteLine("[2] Easy (8 Guesses)");
                Console.WriteLine("[3] Medium (6 Guesses)");
                Console.WriteLine("[4] Hard (4 Guesses)");

                // Prompt the user to choose a difficulty level
                Console.Write("Difficulty: ");
                string difficulty = Console.ReadLine();
                bool successfulOption = Int32.TryParse(difficulty, out tempDifficulty);

                if (successfulOption)
                {
                    if (tempDifficulty > 0 && tempDifficulty < 5)
                    {
                        // If the input for difficulty passes all of the test
                        // set the difficulty as the input, output a message to
                        // the user saying which difficulty they chose & set the
                        // number of guesses allowed to the corresponding difficulty.
                        parsedDifficulty = tempDifficulty;
                        switch (tempDifficulty)
                        {
                            case 1:
                                allowedGuesses = 100;
                                Console.WriteLine("You chose difficulty: Cheater");
                                break;
                            case 2:
                                allowedGuesses = 8;
                                Console.WriteLine("You chose difficulty: Easy");
                                break;
                            case 3:
                                allowedGuesses = 6;
                                Console.WriteLine("You chose difficulty: Medium");
                                break;
                            case 4:
                                allowedGuesses = 4;
                                Console.WriteLine("You chose difficulty: Hard");
                                break;
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid difficulty [1-4]");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid difficulty [1-4]");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Try to guess the secret number! (1-100)");
            Console.WriteLine();

            // Keep allowing the user to guess so long as they are under the allowable amount of guesses
            while (numberOfGuesses < allowedGuesses)
            {
                Console.Write("What's your guess? ");
                string response = Console.ReadLine();

                bool successfulParse = Int32.TryParse(response, out parsedResponse);

                // If the user's guess was appropriate (e.g. an integer between 1 and 100), see if it matches the secret number
                if (successfulParse)
                {
                    // If the user guesses the correct number
                    if (parsedResponse == secretNumber)
                    {
                        Console.WriteLine(@"
 ___ _   _  ___ ___ ___  ___ ___ 
/ __| | | |/ __/ __/ _ \/ __/ __|
\__ \ |_| | (_| (_|  __/\__ \__ \
|___/\__,_|\___\___\___||___/___/
                        ");
                        break;
                    }

                    // If the user guesses the incorrect number
                    else
                    {
                        numberOfGuesses++;

                        // If the user runs out of guesses
                        if (numberOfGuesses == allowedGuesses)
                        {
                            Console.WriteLine($"You're all out of guesses! The secret number was: {secretNumber}");
                        }

                        // If the user still has guesses remaining
                        else
                        {
                            Console.WriteLine($"Guesses Remaining: ({allowedGuesses - numberOfGuesses})");

                            // If the last guess > secret number, let the user know
                            if (parsedResponse > secretNumber)
                            {
                                Console.WriteLine("Your guess was too high!");
                            }

                            // If the last guess < secret number, let the user know
                            else
                            {
                                Console.WriteLine("Your guess was too low!");
                            }

                            // Cheater mode only (Allows for infinite guesses)
                            if (parsedDifficulty == 1)
                            {
                                allowedGuesses++;
                            }

                            Console.WriteLine();
                        }
                    }
                }

                // If the user's guess was not appropriate (1-100), count it as a guess
                else
                {
                    numberOfGuesses++;
                    Console.WriteLine("That is not a number! Try again!");
                    Console.WriteLine($"Guesses Remaining: ({allowedGuesses - numberOfGuesses})");
                    Console.WriteLine();
                }
            }
        }
    }
}
