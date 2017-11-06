using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models
{
    public class Pedido
    {
        public int vendaId { get; set; }
        public int produtoId { get; set; }
        public string descricaoProduto { get; set; }
        public int quantidadeProduto { get; set; }
        public double valorProduto { get; set; }
    }
}