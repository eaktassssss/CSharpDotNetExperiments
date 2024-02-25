using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    public class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public static bool operator >(Date d1, Date d2)
        {
            return (d1.Year > d2.Year) || (d1.Year == d2.Year && d1.Month > d2.Month) || (d1.Year == d2.Year && d1.Month == d2.Month && d1.Day > d2.Day);
        }
        public static bool operator <(Date d1, Date d2)
        {
            return !(d1 > d2) && !(d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day);
        }
    }
}
