using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models
{
    public class produto
    {
        public int produtoId { get; set; }

        public int tipoProdutoId { get; set; }

        public string descricao { get; set; }

        public Nullable<int> quantidade { get; set; }

        public Nullable<decimal> valor { get; set; }

        public Nullable<bool> flagAtivo { get; set; }
    }
}