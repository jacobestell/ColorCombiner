using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace ColorCombinationKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(
                "Please input beginning and end of master panel in the following format: FirstColor,LastColor");
            var firstAndLastInput = Console.ReadLine();
            while (!IsInputValid(firstAndLastInput))
            {
                Console.WriteLine("Could not parse input, Please try again");
                Console.WriteLine(
                    "Please input beginning and end of master panel in the following format: FirstColor,LastColor");
                firstAndLastInput = Console.ReadLine();
            }

            var (head, tail) = GetTupleFromInput(firstAndLastInput);
            var unlocker = new Unlocker<string>(head, tail, new UnlockVerifier<string>());

            Console.WriteLine("Please enter available chips in the following format. Head,Tail");
            Console.WriteLine("Press Enter when complete");

            var chipInput = Console.ReadLine();
            var chipList = new List<Chip<string>>();
            while (IsInputValid(chipInput))
            {
                var result = GetTupleFromInput(chipInput);
                var chipToAdd = new Chip<string>(result.head, result.tail);
                chipList.Add(chipToAdd);
                Console.WriteLine($"Chip {chipToAdd} has been added. Please continue entering chips or press enter to try unlocking.");
                chipInput = Console.ReadLine();
            }

            Console.Clear();
            Console.Write(unlocker.Unlock(chipList));
            Console.ReadLine(); //Keep window open
        }

        private static bool IsInputValid(string input)
        {
            if (!input.Contains(","))
            {
                return false;
            }

            var values = input.Split(',').Select(val => val.Trim()).ToList();
            return !values.Any(string.IsNullOrWhiteSpace) && values.Count == 2;
        }

        private static (string head, string tail) GetTupleFromInput(string input)
        {
            var result = input.Split(',').Select(val => val.Trim()).ToList();
            return (result.First(),result.Last());
        }
    }
}