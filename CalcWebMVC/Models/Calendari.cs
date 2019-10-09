using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;


namespace CalcWebMVC.Models
{
    /// <summary>
    /// Класс содержит элементарные функции для работы с БД.
    /// </summary>
    [DataContract]
    public class Calendari
    {
        [DataMember]
        public List<CalcContext> calcs { get; set; }

        public Calendari() {
            calcs = new List<CalcContext>();
        }

        static string path = @"C:/database/tru/database.json";

        /// <summary>
        /// Загружает БД.
        /// </summary>
        /// <returns></returns>
        public static Calendari Load() {
            if (File.Exists(path))
            {
              
                var role = JsonConvert.DeserializeObject<List<CalcContext>>(File.ReadAllText(path)); //для работы десерилизатора, необходим textReader(поток)

                var newcalc = new Calendari();
                newcalc.calcs = role; 

                if (role == null) {
                        
                    return new Calendari();
                }
                return newcalc;
                
            }
            else
            {
                
                return new Calendari();
            }
        }

        /// <summary>
        /// Cохраняет БД.
        /// </summary>
        public void Safe() {

            if (!File.Exists(path))
            {
                StreamCalc.ExitsFiles(path);
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(calcs, Formatting.Indented));
        }
    }
}
        