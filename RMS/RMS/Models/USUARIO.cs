using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Models
{
    public class USUARIO
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NOMEUSUARIO { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string CPF { get; set; }
    }
}
