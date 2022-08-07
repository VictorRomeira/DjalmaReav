using DjalmaReav.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DjalmaReav.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult cadastroindex()
        {
            return View();
        }

        // GET: Cadastro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cadastro/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.nome = form["nome"];
            cadastro.email = form["email"];
            cadastro.senha = form["senha"];


            if (ModelState.IsValid)
            {

                using (Conexao conexao = new Conexao())
                {
                    var StrQuery = "INSERT INTO Usuario(nome, email, senha) values (@nome, @email, @senha)";
                    SqlCommand comando = new SqlCommand(StrQuery, conexao.conn);
                    comando.Parameters.AddWithValue("@nome", cadastro.nome);
                    comando.Parameters.AddWithValue("@email", cadastro.email);
                    comando.Parameters.AddWithValue("@senha", cadastro.senha);
                    Console.WriteLine(StrQuery);
                    comando.ExecuteNonQuery();
                    return RedirectToAction("cadastroindex");
                }
            }
            return View(cadastro);


        }
        // GET: Cadastro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cadastro/Edit/5
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

        // GET: Cadastro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cadastro/Delete/5
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
