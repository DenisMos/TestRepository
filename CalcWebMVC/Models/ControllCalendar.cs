using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalcWebMVC.Models
{
    /// <summary>
    /// Данный класс предназначен для управлением БД. Содержит методы сортировки, добавления в БД и удаление элемента из БД.
    /// </summary>
    public class ControllCalendar
    {
        /// <summary>
        /// Метод выбирающий из БД только те даты, которые находятся в этом месяце. Возвращает отсортированый список.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<CalcContext> Get(DateTime dt)
        {
            int countDays = DateTime.DaysInMonth(dt.Year, dt.Month);
            DateTime ds = new DateTime(dt.Year, dt.Month, 1);
            DateTime de = new DateTime(dt.Year, dt.AddMonths(1).Month, 1);
            var res = Calendari.Load();
            if (res.calcs != null)
            {
                var evs = res.calcs.Where(e => e.DateKey >= ds && e.DateKey < de).ToList();
                return evs;
            }
            return new List<CalcContext>();
        }

        /// <summary>
        /// Добавляет элемент в БД.
        /// </summary>
        /// <param name="addevent"></param>
        public static void Set(CalcContext addevent) {
            var res = Calendari.Load();
            if (res.calcs == null)
                res.calcs = new List<CalcContext>();
            addevent.Id = res.calcs.Count;
            res.calcs.Add(addevent);
            res.Safe();
        }

        /// <summary>
        /// Удаляет элемент из БД
        /// </summary>
        /// <param name="deleting"></param>
        public static void Delete(CalcContext deleting) {
            var res = Calendari.Load();
            res.calcs = res.calcs.Where(e => e.DateKey != deleting.DateKey && e.Title != deleting.Title).ToList();
            res.Safe();
        }
    }
}