using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RMS.Models
{
    public class ITEMSPAGE
    {
        // Insere o número de registro automaticamente incrementado a cada novo registro, não correndo o risco de se repetir na tabela.
        [PrimaryKey, AutoIncrement] 
        public int ID { get; set; }

        public DateTime DATAENTRADA { get; set; }
        public string TITULO { get; set; }
        public string DESCRICAO { get; set; }
        public string NUMEROSERIE { get; set; }
        public string CATEGORIA { get; set; }
        public string STATUS { get; set; }
        public string MARCA { get; set; }
        public string VALOR { get; set; }

        public ITEMSPAGE()
        {
            // Insere a DATAENTRADA com a data atual do cadastro
            DATAENTRADA = DateTime.Today;
        }

        //public static implicit operator ITEMSPAGE(ITEMSPAGE v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
