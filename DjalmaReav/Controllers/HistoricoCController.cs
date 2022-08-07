using DjalmaReav.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DjalmaReav.Controllers
{
    public class HistoricoCController : Controller
    {
        // GET: HistoricoC
        public ActionResult HistoricoCIndex()
        {
            var idUser = Config.idUser;
            StylishclothesEntities db = new StylishclothesEntities();
            System.Web.UI.WebControls.GridView gView = new System.Web.UI.WebControls.GridView();
            gView.DataSource = db.Calcado.Where(o => o.Idusuario == idUser).ToList();
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