using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RMS.Models
{
    public class USUARIO
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string NOME { get; set; }
        public string DTNASCIMENTO { get; set; }
        public string EMAIL { get; set; }
        public string ENDERECO { get; set; }
        public string CONTATO { get; set; }

        public string CPF { get; set; }
        public string SENHA { get; set; }
        public string PERFIL { get; set; }
    }
}
