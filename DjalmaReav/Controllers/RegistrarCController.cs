using DjalmaReav.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DjalmaReav.Controllers
{
    public class RegistrarCController : Controller
    {
        // GET: RegistrarS
        public ActionResult RegistrarCIndex()
        {
            return View();
        }
        // POST: RegistrarS/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Registro registro = new Registro();
            registro.id = form["Id"];
            registro.tamanho = form["Tamanho"];
            registro.cor = form["Cor"];
            registro.tipo = form["Tipo"];

            var idUser = Config.idUser;

            if (ModelState.IsValid)
            {
                using (Conexao conexao = new Conexao())
                {
                    var StrQuery = "INSERT INTO Calcado(Tamanho, Cor, Tipo, Idusuario) values (@Tamanho, @Cor, @Tipo, @Idusuario)";
                    SqlCommand comando = new SqlCommand(StrQuery, conexao.conn);
                    comando.Parameters.AddWithValue("@Tamanho", registro.tamanho);
                    comando.Parameters.AddWithValue("@Cor", registro.cor);
                    comando.Parameters.AddWithValue("@Tipo", registro.tipo);
                    comando.Parameters.AddWithValue("@Idusuario", idUser);
                    Console.WriteLine(StrQuery);
                    comando.ExecuteNonQuery();
                    return RedirectToAction("RegistrarCIndex");
                }
            }
            return View(registro);
        }
    }
}