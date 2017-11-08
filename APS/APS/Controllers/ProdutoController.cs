using APS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace APS.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult CadastroCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroCategoria(string categoria)
        {
            int loginId = (int)Session["loginId"];
                       
            return View();
        }

        public ActionResult CadastroProduto()
        {            

            return View();
        }
    }
}