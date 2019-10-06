
using Newtonsoft.Json;
using System.IO;

namespace CalcWebMVC.Models
{
    
    /// <summary>
    /// Класс длд работы с записью
    /// </summary>
    public class CalcWrite : StreamCalc
    {
        /// <summary>
        /// Метод сохраняет в базу данных элемент CalcContext. 
        /// Аргумент deleteOld (false: не пересоздовать; true: пересоздать)
        /// </summary>
        public static void SerializationWrite(CalcContext calc,bool deleteOld = false, string path= @"C:/database/database.json")
        {//
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(path, !deleteOld))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(sw, calc);
            }
        }
        /// <summary>
        /// Для моментально очищения всей БД
        /// </summary>
        public static void EmptyWrite(string path = @"C:/database/database.json") {
            StreamWriter sw = new StreamWriter(path);
            sw.Close();
        }
    }
    
}