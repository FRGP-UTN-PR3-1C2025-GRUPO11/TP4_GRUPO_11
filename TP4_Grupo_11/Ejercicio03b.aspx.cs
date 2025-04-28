using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_11
{
    public partial class Ejercicio03b : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;TrustServerCertificate=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idTema = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(idTema))
                {
                    CargarLibros(int.Parse(idTema));
                }
            }
        }

        private void CargarLibros(int idTema)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Libros WHERE IdTema = @idTema", connection);
                cmd.Parameters.AddWithValue("@idTema", idTema);

                SqlDataReader reader = cmd.ExecuteReader();

                gvLibros.DataSource = reader;
                gvLibros.DataBind();
            }
        }
    }
}