using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RMS.Models
{
    public class PEDIDO
    {
        [PrimaryKey]
        public int NUMPEDIDO { get; set; }
        public int ID { get; set; }
        public string PRODUTO { get; set; }
        public DateTime DATAPEDIDO { get; set; }
        public decimal VALORTOTAL { get; set; }
        public int STATUS { get; set; }
        public string FOTO { get; set; }
    }
}
