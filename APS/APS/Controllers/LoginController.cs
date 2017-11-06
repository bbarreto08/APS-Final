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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
            HttpClient client;            
            Usuario usuario;

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));

            try
            {
                HttpResponseMessage response = client.GetAsync("aps/api/login?usuario=" + login + "&senha=" + senha + "&tipoLogin=2").Result;

                if (response.IsSuccessStatusCode)
                {
                    usuario = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result);

                    if (usuario.ErroMsg.Equals(""))
                    {
                        Session["usuario"] = usuario.usuario;
                        Session["loginId"] = usuario.loginId;
                        Session["Id"] = usuario.Id;
                        
                        return RedirectToAction("Index", "Home");

                    } else
                    {
                        ViewBag.MsgErro = "Falha na autenticação. Erro: " + usuario.ErroMsg;
                    }

                } else
                {
                    ViewBag.MsgErro = "Falha na comunicação. Erro: " + (int) response.StatusCode;
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