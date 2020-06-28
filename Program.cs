using System;
using System.Security.Cryptography.X509Certificates;

namespace GuessTheNumber
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool desire = true;

            while (desire)
            {
                Console.WriteLine("Do you want to play? y - yes, n - no");
                string decision = Console.ReadLine().ToUpper();

                if (decision == "Y")
                {
                    InitializingGame();
                }
                else if (decision == "N")
                {
                    desire = false;
                    Console.Clear();
                }
            }
        }

        public static void InitializingGame()
        {
            Console.WriteLine($"Choose the game mode:\n1st: Make up a number(against comp.)\n2nd: Guess the number(comp. making up the number)");

            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 1) new MakeUp().StartGame();
                else if (input == 2) new Guess().StartGame();
                else Console.WriteLine("You should choose only 1 or 2");
            }
            catch
            {
                Console.WriteLine("Choose the game mode 1 or 2!");
            }
        }
    }
}