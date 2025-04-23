using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_11
{
    public partial class Ejercicio01 : System.Web.UI.Page
    {
        private const string cadenaConexion = "Data Source=DESKTOP-CK3UGUB\\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    SqlConnection connection = new SqlConnection(cadenaConexion);
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Provincias", connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    drpDownLstProvincia.DataSource = sqlDataReader;
                    drpDownLstProvincia.DataTextField = "NombreProvincia";
                    drpDownLstProvincia.DataValueField = "IdProvincia";
                    drpDownLstProvincia.DataBind();

                    connection.Close();
                }
        }
    }
}