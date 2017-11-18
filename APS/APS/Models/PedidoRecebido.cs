using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models
{
    public class PedidoRecebido
    {
        public int produtoId { get; set; }
        public int quantidade { get; set; }
        public int ConsumidorId { get; set; }
        public int EstabelecimentoId { get; set; }
    }
}