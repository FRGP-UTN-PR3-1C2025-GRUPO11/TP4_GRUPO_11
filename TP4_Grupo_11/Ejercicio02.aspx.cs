using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_11
{
    public partial class Ejercicio02 : System.Web.UI.Page
    {

  
      private const string cadenaConexion = "Data Source=DESKTOP-B0567DV\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True";
      protected void Page_Load(object sender, EventArgs e)
      {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT IdProducto,NombreProducto,IdProveedor,IdCategoría,CantidadPorUnidad,PrecioUnidad FROM Productos", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                GVEj2.DataSource = reader;
                GVEj2.DataBind();
                
                //DROPDOWN LIST
                ddlProducto.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
                ddlProducto.Items.Insert(1, new ListItem("-- Igual a: --", ""));
                ddlProducto.Items.Insert(2, new ListItem("-- Mayor a: --", ""));
                ddlProducto.Items.Insert(3, new ListItem("-- Mayo a: --", ""));
                connection.Close();
            }

      }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-B0567DV\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Productos WHERE IdCategoría = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", < 6); // Aquí puedes tomar el ID de un TextBox si quieres

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Aquí se hace el DataBind
                    GVEj2.DataSource = table;
                    GVEj2.DataBind();
                }
                connection.Close();

            }
            
        }
    }


}

