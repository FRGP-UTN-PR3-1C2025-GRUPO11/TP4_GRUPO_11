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

        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;TrustServerCertificate=True";
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
                drpDownLstProvincia.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
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

            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccionar --", ""));


            // PROVINCIA FINAL SIN LA PROVINCIA SELECCIONADA EN LA PROVINCIA INICIAL

            SqlCommand sqlCommandProvF = new SqlCommand("SELECT * FROM Provincias WHERE IdProvincia != @IdProvincia", connection);
            sqlCommandProvF.Parameters.AddWithValue("@IdProvincia", provinciaSelec);
            SqlDataReader sqlDataReaderProvF = sqlCommandProvF.ExecuteReader();
            dpProvinciaFinal.DataSource = sqlDataReaderProvF;
            dpProvinciaFinal.DataTextField = "NombreProvincia";
            dpProvinciaFinal.DataValueField = "IdProvincia";
            dpProvinciaFinal.DataBind();
            sqlDataReaderProvF.Close();


            dpProvinciaFinal.Items.Insert(0, new ListItem("-- Seleccionar --", ""));

            // LOCALIDAD FINAL SEGUN LA PROVINCIA FINAL SELECCIONADA

            string provinciaFinalSelec = dpProvinciaFinal.SelectedValue;

            SqlCommand sqlCommandLocF = new SqlCommand("SELECT * FROM Localidades ", connection); // TODO: clausula WHERE de acuerdo a la provincia destino

            //// Siempre actualizar localidades según provincia seleccionada
            sqlCommandLocF.Parameters.AddWithValue("@IdProvincia", provinciaFinalSelec);

            SqlDataReader readerLocF = sqlCommandLocF.ExecuteReader();

            ddlLocalidadFinal.DataSource = readerLocF;
            ddlLocalidadFinal.DataTextField = "NombreLocalidad";
            ddlLocalidadFinal.DataValueField = "IdLocalidad";
            ddlLocalidadFinal.DataBind();
            ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
            readerLocF.Close();


            connection.Close();
        }
    }
}
