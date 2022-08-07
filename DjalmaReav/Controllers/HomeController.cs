using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DjalmaReav.Models;

namespace DjalmaReav.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario e)
        {
            if (ModelState.IsValid)
            {
                using (StylishclothesEntities dc = new StylishclothesEntities())
                {
                    var v = dc.Usuario.Where(a => a.email.Equals(e.email) && a.senha.Equals(e.senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["Logado"] = v.id.ToString();
                        Session["emailUsuarioLogado"] = v.email.ToString();
                        Config.idUser = v.id;
                        return RedirectToAction("botoesindex", "Botoes");
                    }
                }
            }
            return View(e);
        }

        public ActionResult Index()
        {
            if (Session["Logado"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}