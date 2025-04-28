using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_11
{
    public partial class Ejercicio03 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Libreria; Integrated Security = True;TrustServerCertificate=True";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Temas", connection);
                SqlDataReader sqlDatareader = sqlCommand.ExecuteReader();

                ddlTemas.DataSource = sqlDatareader;
                ddlTemas.DataTextField = "Tema";
                ddlTemas.DataValueField = "IdTema";
                ddlTemas.DataBind();

                connection.Close();
            }

            

        }

        protected void lbTemas_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ejercicio03b.aspx");
        }
    }
}