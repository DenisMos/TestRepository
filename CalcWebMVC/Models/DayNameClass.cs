using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalcWebMVC.Models
{
    /// <summary>
    /// Класс для хранения дат и их положения в неделе, месяце.
    /// </summary>
    public class DayNameClass
    {
        public DayNameClass(DateTime dt) {
            DayInWeek = (int)dt.DayOfWeek;
            DayInMonth = dt.Day;
            Month = dt.Month;
            Year = dt.Year;
        }
        public int Month;
        public int DayInWeek;  
        public int DayInMonth;
        public int Year;

        /// <summary>
        /// Метод для подсчёта дней относительно недели.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int Right(int t) {
            if (t >= 7) return t % 7;
            if (t < 0) return 7 + t;
            return t;
        }
    }
}