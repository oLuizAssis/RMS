using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Models
{
    public class CARRINHO
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ID_PRODUTO { get; set; }
        public string FOTO { get; set; }
        public string NOME_PRODUTO { get; set; }
        public double VALOR_PRODUTO { get; set; }
        public double VALOR_TOTAL { get; set; }
        public int QUANTIDADE { get; set; }
    }
}
