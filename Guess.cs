using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber
{
    public class Guess
    {
        public int Number { get; private set; }

        public void StartGame()
        {
            AIPlayer();
            Player();
        }

        private void Player()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your turn!");
            Console.ForegroundColor = ConsoleColor.White;

            int counts = 0;
            do
            {
                int attempt = 0;

                while (!(int.TryParse(Console.ReadLine(), out attempt)))
                {
                    Console.WriteLine("You should input a number!");
                }
                if (attempt > Number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("My number is smaller, try again :)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (attempt < Number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("My number is greater, try again :)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (attempt == Number)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You won! Congrats!");
                }

                counts++;
            } while (counts < 5);

            if (counts >= 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU LOST!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private int AIPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I'm going to make up a number you never guess!");
            Console.ForegroundColor = ConsoleColor.White;

            Random rnd = new Random();

            int value = rnd.Next(0, 100);

            Number = value;

            return value;
        }
    }
}