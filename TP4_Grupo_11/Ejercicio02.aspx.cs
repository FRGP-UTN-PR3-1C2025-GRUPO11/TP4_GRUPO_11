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
                
                connection.Close();
            }

      }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-B0567DV\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True";
            string valorSeleccionado = ddlProducto.SelectedValue;
            if (valorSeleccionado == "1")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Productos WHERE IdProducto = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", txtProducto.Text); // Aquí puedes tomar el ID de un TextBox si quieres

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
            if (valorSeleccionado == "2")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Productos WHERE IdProducto > @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", txtProducto.Text); // Aquí puedes tomar el ID de un TextBox si quieres

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
            if (valorSeleccionado == "3")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Productos WHERE IdProducto < @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", txtProducto.Text); // Aquí puedes tomar el ID de un TextBox si quieres

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


}

