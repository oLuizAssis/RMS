using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RMS.Models
{
    public class PRODUTO
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATAENTRADA { get; set; }
        public DateTime DATASAIDA { get; set; }
        public int ESTOQUE { get; set; }
        public double VALORPRODUTO { get; set; }
        public int STATUS { get; set; }
        public int IDCATEGORIA { get; set; }
        public string FOTO { get; set; }
    }
}
