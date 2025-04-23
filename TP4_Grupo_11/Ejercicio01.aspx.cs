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
    public partial class Ejercicio01 : System.Web.UI.Page
    {
        private const string cadenaConexion = "Data Source=DESKTOP-KQ7K053\\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            if (!IsPostBack)
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Provincias", connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                drpDownLstProvincia.DataSource = sqlDataReader;
                drpDownLstProvincia.DataTextField = "NombreProvincia";
                drpDownLstProvincia.DataValueField = "IdProvincia";
                drpDownLstProvincia.DataBind();
                sqlDataReader.Close();
            }


            // Siempre actualizar localidades según provincia seleccionada
            string provinciaSelec = drpDownLstProvincia.SelectedValue;

            SqlCommand sqlB = new SqlCommand("SELECT * FROM Localidades WHERE IdProvincia = @IdProvincia", connection);
            sqlB.Parameters.AddWithValue("@IdProvincia", provinciaSelec);

            SqlDataReader reader = sqlB.ExecuteReader();

            ddlLocalidad.DataSource = reader;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();
            reader.Close();

            connection.Close();
        }

    }
}
