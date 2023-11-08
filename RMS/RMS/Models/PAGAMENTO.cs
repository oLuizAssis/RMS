using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RMS.Models
{
    public class PAGAMENTO
    {
        [PrimaryKey]
        public int DOCPAGO { get; set; }
        public string BANCO { get; set; }
        public DateTime DTPAG { get; set; }
        public decimal VLPAG { get; set; }
        public int SITPAG { get; set; }
        public int QTDPARCELAS { get; set; }

    }
}
