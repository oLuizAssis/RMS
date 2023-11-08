using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RMS.Models
{
    public class CATEGORIA
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string NOMECATEGORIA { get; set; }
        public int IDCATEGORIAPAI { get; set; }
        public int STATUS { get; set; }
    }
}
