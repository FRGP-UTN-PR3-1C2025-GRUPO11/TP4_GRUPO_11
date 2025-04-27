using System;
using System.Collections.Generic;
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

  
      private const string cadenaConexion = "Data Source=DESKTOP-KQ7K053\\SQLEXPRESS;Initial Catalog = Neptuno; Integrated Security = True; Encrypt=True;TrustServerCertificate=True";
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
            }
      }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT IdProducto,NombreProducto,IdProveedor,IdCategoría,CantidadPorUnidad,PrecioUnidad FROM Productos", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                GVEj2.DataSource = reader;
                GVEj2.DataBind();
               //SqlParameter parameter = sqlCommand.Parameters.Add("@IdProducto", sqlDbType:int);
               //parameter.Value = txtProducto.Text;

           


        }
    }


}

