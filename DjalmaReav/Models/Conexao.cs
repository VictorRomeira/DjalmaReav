using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DjalmaReav.Models
{
    public class Conexao : IDisposable
    {
        public SqlConnection conn;

        public Conexao()
        {
            conectar();
        }

        private void conectar()
        {
            string strconx = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Stylishclothes;Data Source=DESKTOP-JGDOCUR\\SQLEXPRESS";
            conn = new SqlConnection(strconx);

            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }

        public void FecharConexao()
        {
            conn.Close();
            conn.Dispose();
        }


    }
}



