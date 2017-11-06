using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models
{
    public class Usuario
    {
        public int loginId { get; set; }
        public string usuario { get; set; }
        public int Id { get; set; }
        public string ErroMsg { get; set; }
    }
}