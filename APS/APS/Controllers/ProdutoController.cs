using APS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:56652/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

            tipoProduto tipoProduto = new tipoProduto { descricao = categoria, flagAtivo = true, idEstabelecimento = loginId };
            RequestPutTipoProduto RequestPutTipoProduto = new RequestPutTipoProduto();
            RequestPutTipoProduto.TiposProduto.Add(tipoProduto);

            string parm = JsonConvert.SerializeObject(RequestPutTipoProduto);

            var content = new StringContent(parm, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = client.PostAsync("/api/TipoProdutos", content).Result;

            }
            catch (Exception e)
            {

                throw;
            }

            return View();
        }

        public ActionResult CadastroProduto()
        {            
            return View("CadastrarProduto");
        }

        [HttpPost]
        public ActionResult CadastroProduto(produto produto)
        {

            RequestPutProduto RequestPutProduto = new RequestPutProduto();
            RequestPutProduto.Produtos.Add(produto);

            int loginId = (int)Session["loginId"];
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:56652/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));                       

            string parm = JsonConvert.SerializeObject(RequestPutProduto);

            var content = new StringContent(parm, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = client.PostAsync("/api/Produtos", content).Result;

            }
            catch (Exception e)
            {

                throw;
            }


            return RedirectToAction("Index", "Home");
        }
    }
}