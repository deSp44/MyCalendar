using System;
using System.Collections.Generic;
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

        public static bool IsValidDate(int year, int month, int day)
        {
            return (year > DateTime.MinValue.Year && year <= DateTime.MaxValue.Year) || (month >= DateTime.MinValue.Month && month <= DateTime.MaxValue.Month) || (day >= DateTime.MinValue.Day && day <= DateTime.DaysInMonth(year, month));
        }

        public static void ConfirmOperation()
        {

        }


    }
}