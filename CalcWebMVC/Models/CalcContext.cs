using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data.Sql;

namespace CalcWebMVC.Models
{
    [DataContract]
    public class CalcContext
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime DateKey { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Message { get; set; }

       

        public CalcContext()
        {
            
        }

        public CalcContext(DateTime DateKey, string title, string message)
        {
            this.DateKey = DateKey;
            this.Title = title;
            this.Message = message;
         
        }

        public bool isEquel(DateTime dt1, DateTime dt2) {
            if (dt1.Date == dt2.Date && dt1.Day == dt2.Day && dt1.Year == dt2.Year)
                return true;
            else
                return false;
        }


        public void SerializationWrite() {//
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(@"C:/database/database.json", true))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(sw, this);

            }
        }

        public void SerializationWriteDeleteOld()//
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(@"C:/database/database.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(sw, this);
                writer.Close();
            }
        }

        public static void ExitsFiles(string paths) {
            if (!Directory.Exists(@"C:/database"))
            {
                Directory.CreateDirectory(@"C:/database");
                if (!File.Exists(@"C:/database/database.json"))
                {
                    StreamWriter sw = new StreamWriter(@"C:/database/database.json");
                    sw.Close();
                }
            }
           
        }

        public static Object DeserializationComponents()//
        {
            IList<CalcContext> calc =  new List<CalcContext>();
            ExitsFiles(@"C:/database/database.json");
            using (StreamReader file = new StreamReader(@"C:/database/database.json"))
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

        public static CalcContext SerializationRead(DateTime time)//
        {
            CalcContext movie2 = null;
            ExitsFiles(@"C:/database/database.json");
            using (StreamReader file = new StreamReader(@"C:/database/database.json"))
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

                    if (time == role.DateKey) {
                        movie2 = role;
                        break;
                    }
                }
               
            }
            return (movie2);
        }

        public static CalcContext Find(DateTime time, string title) {
            IList<CalcContext> calcs = new List<CalcContext>();
            calcs = DeserializationComponents() as List<CalcContext>;
            foreach (CalcContext cl in calcs) {
                if (cl.DateKey == time && cl.Title == title) {
                    return cl;
                }
            }
            return null;
        }

        public static void DeleteCalcFromJSON(CalcContext calc) {//
            IList < CalcContext > calcs = new List<CalcContext>();
            calcs = DeserializationComponents() as List<CalcContext>;

            StreamWriter sw = new StreamWriter(@"C:/database/database.json");
            sw.Close();


            if (calcs.Count > 0)
            {
                for (int i = 0; i < calcs.Count; i++)
                {
                    if (calc.Title != calcs[i].Title || calc.DateKey != calcs[i].DateKey)
                        calcs[i].SerializationWrite();
                }
            }
        }

        public void DatabaseAdd() {
            
        }
    }
    
    
}