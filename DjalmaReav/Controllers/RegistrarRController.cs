using DjalmaReav.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DjalmaReav.Controllers
{
    public class RegistrarRController : Controller
    {
        // GET: NovoRegistro
        public ActionResult RegistrarRIndex()
        {
            return View();
        }

        // GET: NovoRegistro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NovoRegistro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrarRIndex/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Registro registro = new Registro();
            registro.id = form["Id"];
            registro.tamanho = form["Tamanho"];
            registro.cor = form["Cor"];
            registro.tipo = form["Tipo"];
            registro.estampa = form["Estampa"];

            var idUser = Config.idUser;

            if (ModelState.IsValid)
            {
                using (Conexao conexao = new Conexao())
                {
                    var StrQuery = "INSERT INTO Roupa(Tamanho, Cor, Tipo, Estampa, Idusuario) values (@Tamanho, @Cor, @Tipo, @Estampa, @Idusuario)";
                    SqlCommand comando = new SqlCommand(StrQuery, conexao.conn);
                    comando.Parameters.AddWithValue("@Tamanho", registro.tamanho);
                    comando.Parameters.AddWithValue("@Cor", registro.cor);
                    comando.Parameters.AddWithValue("@Tipo", registro.tipo);
                    comando.Parameters.AddWithValue("@Estampa", registro.estampa);
                    comando.Parameters.AddWithValue("@Idusuario", idUser);
                    Console.WriteLine(StrQuery);
                    comando.ExecuteNonQuery();
                    return RedirectToAction("RegistrarRIndex");
                }
            }
            return View(registro);
        }

        // GET: NovoRegistro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NovoRegistro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NovoRegistro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NovoRegistro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
