using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CalcWebMVC.Models
{
    /// <summary>
    /// Здесь вынесены все остальные вспомогательные функции для класса CalcContext.
    /// Поис элемента, удаление в бд.
    /// </summary>
    public class SupportCalc
    {
        /// <summary>
        /// Метод связан на прямую с методом DeserelizationContext. 
        /// Он получает список. В нём ищет один из элементов по ключам time, title
        /// </summary>
        /// <param name="time"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static CalcContext Find(DateTime time, string title)
        {
            IList<CalcContext> calcs = new List<CalcContext>();
            calcs = CalcRead.DeserializationComponents() as List<CalcContext>;
            foreach (CalcContext cl in calcs)
            {
                if (cl.DateKey == time && cl.Title == title)
                {
                    return cl;
                }
            }
            return null;
        }

        /// <summary>
        /// Метод получает список(Иcпользует DeseralizationContext). Удаляет определённый CalcContext
        /// из базы данных.
        /// </summary>
        /// <param name="calc"></param>
        public static void DeleteCalcFromJSON(CalcContext calc)
        {//
            IList<CalcContext> calcs = new List<CalcContext>();
            calcs = CalcRead.DeserializationComponents() as List<CalcContext>;

            CalcWrite.EmptyWrite();

            if (calcs.Count > 0)
            {
                for (int i = 0; i < calcs.Count; i++)
                {
                    if (calc.Title != calcs[i].Title || calc.DateKey != calcs[i].DateKey)
                        CalcWrite.SerializationWrite(calcs[i]);
                }
            }
        }

    }
}