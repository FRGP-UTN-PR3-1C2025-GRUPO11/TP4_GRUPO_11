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
using static System.Net.Mime.MediaTypeNames;

namespace TP4_Grupo_11
{
    public partial class Ejercicio02 : System.Web.UI.Page
    {

        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
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
            string valorProducto = ddlProducto.SelectedValue;
            string valorCategoria = ddlCategoria.SelectedValue;

            string idProducto = txtProducto.Text.Trim();
            string idCategoria = txtCategoria.Text.Trim();

            List<string> condiciones = new List<string>();
            SqlCommand command = new SqlCommand();

            if (!string.IsNullOrWhiteSpace(idProducto))
            {
                switch (valorProducto)
                {
                    case "1":
                        condiciones.Add("IdProducto = @idProducto");
                        command.Parameters.AddWithValue("@idProducto", idProducto);
                        break;
                    case "2":
                        condiciones.Add("IdProducto > @idProducto");
                        command.Parameters.AddWithValue("@idProducto", idProducto);
                        break;
                    case "3":
                        condiciones.Add("IdProducto < @idProducto");
                        command.Parameters.AddWithValue("@idProducto", idProducto);
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(idCategoria))
            {
                switch (valorCategoria)
                {
                    case "1":
                        condiciones.Add("IdCategoría = @idCategoria");
                        command.Parameters.AddWithValue("@idCategoria", idCategoria);
                        break;
                    case "2":
                        condiciones.Add("IdCategoría > @idCategoria");
                        command.Parameters.AddWithValue("@idCategoria", idCategoria);
                        break;
                    case "3":
                        condiciones.Add("IdCategoría < @idCategoria");
                        command.Parameters.AddWithValue("@idCategoria", idCategoria);
                        break;
                }
            }

            string query = "SELECT IdProducto, NombreProducto, IdProveedor, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";

            if (condiciones.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", condiciones);
            }

            command.CommandText = query;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                command.Connection = connection;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                GVEj2.DataSource = table;
                GVEj2.DataBind();
            }
        }


        protected void btnBorrarFiltro(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT IdProducto,NombreProducto,IdProveedor,IdCategoría,CantidadPorUnidad,PrecioUnidad FROM Productos", sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            GVEj2.DataSource = reader; 
            GVEj2.DataBind();

            sqlConnection.Close();

            txtProducto.Text = "";
            txtCategoria.Text = "";
            ddlProducto.SelectedIndex = 1;
            ddlCategoria.SelectedIndex = 1;
        }
    }
}