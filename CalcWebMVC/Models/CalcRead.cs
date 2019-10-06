using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CalcWebMVC.Models
{

    /// <summary>
    /// Класс для раболты с БД. Способен считывать как один элемент, так и всю бд одним листом.
    /// </summary>
    public class CalcRead : StreamCalc
    {
        /// <summary>
        /// Получение всего списка CalcContext
        /// </summary>
        /// <returns></returns>
        public static Object DeserializationComponents(string path = @"C:/database/database.json")//
        {
            IList<CalcContext> calc = new List<CalcContext>();
            
            ExitsFiles(path);
            using (StreamReader file = new StreamReader(path))
            {
                JsonTextReader reader = new JsonTextReader(file);
                reader.SupportMultipleContent = true;

                while (true)
                {
                    if (!reader.Read())
                    {
                        break;
                    }

                    JsonSerializer serializer = new JsonSerializer();
                    CalcContext role = serializer.Deserialize<CalcContext>(reader);
                    calc.Add(role);
                }

            }
            return (calc);
        }

        /// <summary>
        /// Читает базу данных, получает из неё один элемент по времени.
        /// Возвращает CalcContext
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static CalcContext SerializationRead(DateTime time, string path = @"C:/database/database.json")//
        {
            CalcContext movie2 = null;
            ExitsFiles(path);
            using (StreamReader file = new StreamReader(path))
            {
                JsonTextReader reader = new JsonTextReader(file);
                reader.SupportMultipleContent = true;

                while (true)
                {
                    if (!reader.Read())
                    {
                        break;
                    }

                    JsonSerializer serializer = new JsonSerializer();
                    CalcContext role = serializer.Deserialize<CalcContext>(reader);

                    if (time == role.DateKey)
                    {
                        movie2 = role;
                        break;
                    }
                }

            }
            return (movie2);
        }

       
    }
}