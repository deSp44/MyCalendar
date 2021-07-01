using System;
using System.Globalization;

namespace MyCalendarApp.Helpers
{
    public static class CheckValid
    {
        public static DateTime IsValidDate()
        {
            var isValid = false;
            var correctDate = DateTime.Now;

            while (!isValid)
            {
                isValid = DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out correctDate);
                if (!isValid)
                    Console.Write("Enter date again, but in correct format: ");
            }
            return correctDate;
        }

        public static ConsoleColor IsValidColor()
        {
            var isValid = false;
            var correctColor = 0;

            while (!isValid)
            {
                Console.Write("> ");
                isValid = int.TryParse(Console.ReadLine(), out correctColor);
                if (correctColor is >= 0 and <= 15) 
                    continue;

                Console.WriteLine("Invalid color! Enter correct number.");
                isValid = false;
            }
            return (ConsoleColor)correctColor - 1;
        }

        public static int IsInputNumber(int maxNumber)
        {
            var isValid = false;
            var correctNumber = 0;

            while (!isValid)
            {
                isValid = int.TryParse(Console.ReadLine(), out correctNumber);
                if (correctNumber >= 1 && correctNumber <= maxNumber)
                    continue;

                Console.Write("Enter correct number: ");
                isValid = false;
            }
            return correctNumber;
        }

        public static bool IsBusy()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input != null)
                    switch (input.ToUpper())
                    {
                        case "FREE":
                            return false;
                        case "BUSY":
                            return true;
                    }

                Console.Write("Wrong input. Type FREE or BUSY: ");
            }
        }

        public static bool CheckYesOrNo()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input != null)
                    switch (input.ToUpper())
                    {
                        case "YES":
                            return true;
                        case "NO":
                            return false;
                    }

                Console.Write("Wrong input. Type YES or NO: ");
            }
        }
    }
}