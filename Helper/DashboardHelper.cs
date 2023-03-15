using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Helper
{
    public class DashboardHelper
    {
        public static string getMonthNameByNumber(int Month)
        {
            string MonthName = "";
            switch (Month)
            {
                case 1:
                    MonthName = "JAN";
                    break;
                case 2:
                    MonthName = "FEB";
                    break;
                case 3:
                    MonthName = "MAR";
                    break;
                case 4:
                    MonthName = "APR";
                    break;
                case 5:
                    MonthName = "MAY";
                    break;
                case 6:
                    MonthName = "JUN";
                    break;
                case 7:
                    MonthName = "JUL";
                    break;
                case 8:
                    MonthName = "AUG";
                    break;
                case 9:
                    MonthName = "SEP";
                    break;
                case 10:
                    MonthName = "OCT";
                    break;
                case 11:
                    MonthName = "NOV";
                    break;
                case 12:
                    MonthName = "DEC";
                    break;
                default:
                    MonthName = "not a valid Month";
                    break;
            }
            return MonthName;
        }
    }
}
