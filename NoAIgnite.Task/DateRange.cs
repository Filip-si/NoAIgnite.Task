using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoAIgnite.Task
{
    public class DateRange
    {
        public DateRange(string FromDate, string ToDate)
        {
            this.FromDate = FromDate;
            this.ToDate = ToDate;
        }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        string[] formats = { 
            "dd.MM.yyyy","d.M.yyyy", "dd.M.yyyy", "d.MM.yyyy",
            "dd/MM/yyyy","d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy",
            "yyyy-MM-dd","yyyy-M-d", "yyyy-M-dd", "yyyy-MM-d"
        };

        public bool IsFromDateEarlierThanToDate(string fromDate, string toDate)
        {
            var from = DateTime.TryParseExact(
                fromDate, 
                formats, 
                System.Globalization.CultureInfo.InvariantCulture, 
                System.Globalization.DateTimeStyles.None, 
                out DateTime dateEarlier);
            var to = DateTime.TryParseExact(
                toDate, 
                formats, 
                System.Globalization.CultureInfo.InvariantCulture, 
                System.Globalization.DateTimeStyles.None, 
                out DateTime dateLater);

            if (from == to == true && dateEarlier < dateLater)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ReturnSeparator(string fromDate, string toDate)
        {
            if (fromDate.Contains(".") && toDate.Contains("."))
            {
                return ".";
            }
            else if (fromDate.Contains("/") && toDate.Contains("/"))
            {
                return "/";
            }
            else if (fromDate.Contains("-") && toDate.Contains("-"))
            {
                return "-";
            }
            else
                throw new Exception("Separator in entered date not recognized.");
        }

        public void PrintDateRange(string fromDate, string toDate, string separator)
        {
            if (DateTime.TryParse(fromDate, out DateTime theDate1) && DateTime.TryParse(toDate, out DateTime theDate2))
            {
                if (theDate1.Year != theDate2.Year)
                {
                    Console.WriteLine(theDate1.Day + separator + theDate1.Month + separator + theDate1.Year + " - " + theDate2.Day + separator + theDate2.Month + separator + theDate2.Year);
                }
                else if (theDate1.Month != theDate2.Month)
                {
                    Console.WriteLine(theDate1.Day + separator + theDate1.Month + " - " + theDate2.Day + separator + theDate2.Month + separator + theDate2.Year);
                }
                else
                {
                    Console.WriteLine(theDate1.Day + " - " + theDate2.Day + separator + theDate2.Month + separator + theDate2.Year);
                }
            }
            else
            {
                throw new Exception("Wrong date format");
            }
        }
    }
}
