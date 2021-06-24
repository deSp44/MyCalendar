using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendarApp.Helpers
{
    public static class CheckValid
    {
        public static int IsValidInput(string value)
        {
            var success = int.TryParse(value, out var number);
            return success ? number : 0;
        }

        public static DateTime IsValidDate()
        {
            var isValid = false;
            DateTime correctDate = DateTime.Now;

            while (!isValid)
            {
                isValid = DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out correctDate);
                if (!isValid)
                    Console.Write("Enter date again, but in correct format: ");
            }
            return correctDate;
        }

        public static void ConfirmOperation()
        {

        }


    }
}