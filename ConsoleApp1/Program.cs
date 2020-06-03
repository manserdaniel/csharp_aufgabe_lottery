using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LotteryTicket lotteryTicket = new LotteryTicket();

            LotteryTipp winningNumbers = new LotteryTipp();

            winningNumbers.tipps = GetRandomIntArray(6, 1, 6);

            var count = 0;
            bool giveUp = false; 

            while (count < 5 && !giveUp)
            {
                count = 0;
                LotteryTipp newTipp = new LotteryTipp();
                Console.WriteLine("Geben sie nacheinander 6 Zahlen ein: ");

                for (var i = 0; i < 6; i++)
                {
                    int.TryParse(Console.ReadLine(), out var singleTipp);
                    newTipp.tipps[i] = singleTipp;
                }

                lotteryTicket.ticket.Add(newTipp);

                for (var i = 0; i < 6; i++)
                {
                    if (lotteryTicket.ticket[0].tipps[i] == winningNumbers.tipps[i])
                    {
                        count++;
                    }
                }
                if (count >= 6)
                {
                    break;
                }
                Console.WriteLine($"Sie haben {count} Zahlen richtig geraten. Geben sie auf? (Y/N)");
                var answer = Console.ReadLine();

                giveUp = answer.ToLower() == "y" ? true : false;
            }

            Console.WriteLine($"{winningNumbers.tipps[0]} {winningNumbers.tipps[1]} {winningNumbers.tipps[2]} {winningNumbers.tipps[3]} {winningNumbers.tipps[4]} {winningNumbers.tipps[5]}");

            int[] GetRandomIntArray(int arraySize, int minNumber, int maxNumber)
            {
                Random randomizer = new Random();
                var intArray = new int[arraySize];

                for (int i = 0; i < arraySize; i++)
                {
                    intArray[i] = randomizer.Next(minNumber, maxNumber + 1);
                }

                return intArray;
            }
        }
    }
}
