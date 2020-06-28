using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber
{
    public class MakeUp
    {
        public int Number { get; private set; }

        public void StartGame()
        {
            AskNumber();
            AIPlayer();
        }

        public int AskNumber()
        {
            int number = -1;
            bool firstAttempt = true;
            do
            {
                if (!firstAttempt)
                {
                    Console.WriteLine("Incorrect number try again.");
                }

                Console.WriteLine("Make up a number between 0 and 100:");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    Number = number;
                }
                catch
                {
                    Console.WriteLine($"Your input is not a number.");
                }

                firstAttempt = false;
            } while (!(number >= 0 && number <= 100));
            Console.WriteLine($"Your number is {number}");

            return number;
        }

        public void AIPlayer()
        {
            //creating a view of real AI Player;
            string message = "I'll be your opponent! Beware!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            CreatingMinds();
        }

        private void CreatingMinds()
        {
            List<int> list = new List<int>();

            int count = 0;
            while (count < 100)
            {
                list.Add(count);
                count++;
            }

            int startIndex = 0;
            int endIndex = list.Count;

            BinarySearch(list, ref startIndex, ref endIndex);
        }

        private void BinarySearch(List<int> list, ref int startIndex, ref int endIndex)
        {
            int attempts = 0;
            int interBuf = 0;

            do
            {
                interBuf = (startIndex + endIndex) / 2;
                //first attempt to guess;
                Console.WriteLine($"Your number is {interBuf}");

                if (list[interBuf] == Number) break;

                string mes = Console.ReadLine();
                string message = mes.ToUpper();

                while (message != "GREATER" && message != "SMALLER")
                {
                    Console.WriteLine("You should write \"greater\" or \"smaller\" according ot the condition.");
                    mes = Console.ReadLine();
                    message = mes.ToUpper();
                }

                //checking the input;
                if (message == "GREATER")
                {
                    //checking the indexes and implementing them;
                    startIndex = interBuf;
                }
                else if (message == "SMALLER")
                {
                    //checking the indexes and implementing them;

                    endIndex = interBuf;
                }

                attempts++;
            } while (attempts < 5);

            if (interBuf == Number)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lost!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You won! Congrats!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}