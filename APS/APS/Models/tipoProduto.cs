using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models
{
    public class tipoProduto
    {
        public int tipoProdutoId { get; set; }

        public int idEstabelecimento { get; set; }

        public string descricao { get; set; }

        public Nullable<bool> flagAtivo { get; set; }
    }
}