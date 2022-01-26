using System;

namespace NoAIgnite.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello type date and display as date range:");
            Console.WriteLine("Enter earlier date ex. (01.01.2022, 01/01/2022, 2022-01-01)");
            string fromDate = Console.ReadLine();
            Console.WriteLine("Enter later date ex. (02.01.2022, 02/01/2022, 2022-01-02)");
            string toDate = Console.ReadLine();

            DateRange dateRange = new DateRange(fromDate, toDate);

            if (dateRange.IsFromDateEarlierThanToDate(fromDate, toDate))
            {
                var separator = dateRange.ReturnSeparator(fromDate, toDate);

                dateRange.PrintDateRange(fromDate, toDate, separator);
            }
            else
            {
                throw new Exception("Wrong range of dates.");
            }

            

        }
    }
}
