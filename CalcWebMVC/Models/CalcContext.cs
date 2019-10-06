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
        /// <summary>
        /// Метод проверки на равенство двух дат
        /// </summary>
        /// <param name="Первая дата"></param>
        /// <param name="Вторая дата"></param>
        /// <returns></returns>
        public bool isEquel(DateTime dt1, DateTime dt2)
        {
            if (dt1.Date == dt2.Date && dt1.Day == dt2.Day && dt1.Year == dt2.Year)
                return true;
            else
                return false;
        }

    }
}