using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Models
{
    public class FUNCIONARIO
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NOMEFUNCIONARIO { get; set; }
        public string CPFFUNCIONARIO { get; set; }
        public string DTNASCFUNCIONARIO { get; set; }
        public string CARGO { get; set; }
        public string EMAILFUNCIONARIO { get; set; }
        public string ENDERECOFUNCIONARIO { get; set; }
        public string CONTATOFUNCIONARIO { get; set; }        
        public string SENHA { get; set; }
        public string PERFIL { get; set; }
    }
}
