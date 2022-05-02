using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Databaze
{
    public class Avenger
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Gender { get; set; }


    }
}
