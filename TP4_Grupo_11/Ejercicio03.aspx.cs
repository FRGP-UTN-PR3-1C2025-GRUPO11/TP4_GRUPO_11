using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_11
{
    public partial class Ejercicio03 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=DESKTOP-6LDIHKB\SQLEXPRESS;Initial Catalog = Libreria; Integrated Security = True;TrustServerCertificate=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
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

                ddlTemas.Items.Insert(0, new ListItem("-Seleccionar tema--", "0"));


                connection.Close();
            }



        }

        protected void btnVerLibros_Click(object sender, EventArgs e)
        {
            string idTema = ddlTemas.SelectedValue;
            Response.Redirect("Ejercicio03b.aspx?id=" + idTema);
        }

        protected void ddlTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlTemas.SelectedIndex)
            {
                case 0:
                    btnVerLibros.Text = "Ver Libros";
                    break;
                case 1:
                    btnVerLibros.Text = "Ver Tema 1";
                    break;
                case 2:
                    btnVerLibros.Text = "Ver Tema 2";
                    break;
                case 3:
                    btnVerLibros.Text = "Ver Tema 3";
                    break;

            }
        }
    }
}
