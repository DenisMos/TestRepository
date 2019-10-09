using System;
using System.Runtime.Serialization;


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
        

    }
}