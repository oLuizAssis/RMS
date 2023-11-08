using System;
using System.Collections.Generic;
using System.Text;

//Luiz

namespace RMS.Models
{
    internal class ItemCarrinho
    {
        public string ItemId { get; set; }

        public string CarrinhoId { get; set; }

        public int Quantidade { get; set; }

        public System.DateTime DataCriacao { get; set; }

        public int ID_PRODUTO { get; set; }

        public virtual PRODUTO PRODUTO { get; set; }
    }
}

