using APS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace APS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? pagina)
        {
            HttpClient client = new HttpClient();

            if(Session["loginId"] == null || Session["loginId"].Equals(""))
            {
                return RedirectToAction("Index", "Login");
            }

            int loginId = (int) Session["loginId"];

            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

            try
            {
                HttpResponseMessage response = client.GetAsync("aps/api/vendas?idEmpresa=" + loginId).Result;

                if (response.IsSuccessStatusCode)
                {
                    Vendas vendas = JsonConvert.DeserializeObject<Vendas>(response.Content.ReadAsStringAsync().Result);

                    Session["Vendas"] = vendas;

                    int tamanhoPagina = 10;
                    int numeroPagina = pagina ?? 1;
                    PagedList<Venda> pd = new PagedList<Venda>(vendas.vendas, numeroPagina, tamanhoPagina);
                    return View(pd);

                }

            }
            catch (Exception e)
            {

                throw;
            }

            return View();
        }
        
        public ActionResult Detalhes(int vendaId)
        {
            
            var tempListVenda = Session["Vendas"];
            Session["vendaId"] = vendaId;

            Vendas listVenda = (Vendas) tempListVenda;
       
            Venda venda = listVenda.vendas.Where(a => a.vendaId == vendaId).FirstOrDefault();

            return View(venda.pedido);
        }

        public ActionResult Baixar()
        {

            // List<Venda> listVenda = (List<Venda>) Session["Vendas"] as dynamic;

            var tempListVenda = Session["Vendas"];
            int vendaId = (int)Session["vendaId"];

            Vendas listVenda = (Vendas)tempListVenda;            


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56652/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                
                string vendaSerialized = JsonConvert.SerializeObject(new { vendaId = vendaId } );

                var content = new StringContent(vendaSerialized, Encoding.UTF8, "application/json");
                //POST                
                HttpResponseMessage  response = client.GetAsync("api/Vendas/Baixar?vendaId=" + vendaId).Result;

            }

            return RedirectToAction("Index", "Home");
        }

    }
}