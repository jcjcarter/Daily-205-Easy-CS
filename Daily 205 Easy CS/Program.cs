using System;

namespace Daily_205_Easy_CS
{
    class Program
    {
        public static DateTime StartDate;
        public static DateTime EndDate;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a date range:");
            var dateRangeInput = Console.ReadLine();
            Console.WriteLine();
            if (!IsValidInput(dateRangeInput))
            {
                Console.WriteLine("Please enter a valid date range using the format YYYY-MM-DD YYYY-MM-DD.");
            }
            else
            {
                var isSingleDay = StartDate == EndDate;
                var isSingleMonth = (StartDate.Month == EndDate.Month
                    && StartDate.Year == EndDate.Year);
                var isSingleYear = (EndDate - StartDate < new TimeSpan(365, 0, 0, 0, 0));
                Console.WriteLine("Result:");
                if (isSingleDay)
                {
                    Console.WriteLine(FormatDate(StartDate, true));
                }
                else if (isSingleMonth)
                {
                    Console.WriteLine(FormatDate(StartDate, false) + " - " + CreateOrdinalNumber(EndDate.Day));
                }
                else if (isSingleYear)
                {
                    Console.WriteLine(FormatDate(StartDate, false) + " - " + FormatDate(EndDate, StartDate.Year != DateTime.Today.Year));
                }
                else
                {
                    Console.WriteLine(FormatDate(StartDate, true) + " - " + FormatDate(EndDate, true));
                }
            }
            Console.Read();
        }
        static bool IsValidInput(string dateRangeInput)
        {
            var datesInput = dateRangeInput.Split(' ');
            var startDateInput = datesInput[0];
            var endDateInput = datesInput[1];
            DateTime startDate;
            DateTime endDate;
            if (DateTime.TryParse(startDateInput, out startDate) 
                && DateTime.TryParse(endDateInput, out endDate))
            {
                StartDate = startDate;
                EndDate = endDate;
                return true;
            }
            else
            {
                return false;
            }

        }
        static string FormatDate(DateTime date, bool includeYear)
        {
            var dateString = date.ToString("MMMM") + " " + CreateOrdinalNumber(date.Day);
            if (includeYear)
            {
                dateString += ", " + date.ToString("yyyy");
            }
            return dateString;
        }
        static string CreateOrdinalNumber(int number)
        {
            var numberString = number.ToString();
            if (numberString.EndsWith("1") && number != 11)
            {
                return numberString + "st";
            }
            else if (numberString.EndsWith("2") && number != 12)
            {
                return numberString + "nd";
            }
            else if (numberString.EndsWith("3") && number != 13)
            {
                return numberString + "rd";
            }
            else
            {
                return numberString + "th";
            }
        }
    }
}
