using APS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace APS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            int loginId = (int) Session["loginId"];

            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));

            try
            {
                HttpResponseMessage response = client.GetAsync("aps/api/vendas?idEmpresa=" + loginId).Result;

                if (response.IsSuccessStatusCode)
                {
                    Vendas vendas = JsonConvert.DeserializeObject<Vendas>(response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return View();
        }

    }
}