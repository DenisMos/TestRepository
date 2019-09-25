using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalcWebMVC.Models
{
    public class EventRequest : DbContext
    {
        public DbSet<CalcContext> CalcContexts { get; set; }

        
    }

    //Нигде не используется, необходим для работы базы данных entityFramework, которая отключена
}