using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Models
{
    public class PRODUTO
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TITULO { get; set; }
        public string DESCRIÇÃO { get; set; }
    }
}
