using System;

namespace GuessingGame
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Try to guess the secret number!");
            Console.Write("What's your guess? ");
            string response = Console.ReadLine();
            Console.WriteLine($"You guessed {response}!");
        }
    }
}
