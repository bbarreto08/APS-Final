using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models
{
    public class Venda
    {
        public int vendaId { get; set; }
        public int consumidorId { get; set; }
        public int idEstabelecimento { get; set; }
        public DateTime dataVenda { get; set; }
        public bool flagAtivo { get; set; }
        public List<Pedido> pedido { get; set; }
    }
}