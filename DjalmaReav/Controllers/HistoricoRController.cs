using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DjalmaReav.Models;

namespace DjalmaReav.Controllers

{
    public class HistoricoRController : Controller
    {
        // GET: Home
        public ActionResult HistoricoRIndex()
        {
            var idUser = Config.idUser;
            StylishclothesEntities db = new StylishclothesEntities();
            System.Web.UI.WebControls.GridView gView = new System.Web.UI.WebControls.GridView();
            gView.DataSource = db.Roupa.Where(o => o.Idusuario == idUser).ToList();
            gView.DataBind();
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw))
                {
                    gView.RenderControl(htw);
                    ViewBag.GridViewString = sw.ToString();
                }
            }
            return View();
        }
    }
}