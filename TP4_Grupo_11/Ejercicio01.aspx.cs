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
    public partial class Ejercicio01 : System.Web.UI.Page
    {

        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;TrustServerCertificate=True";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarProvinciaInicio();

            }
        }

        public void cargarProvinciaInicio()
            // es la carga inicial. luego con un evento en otra funcion decimos que hacemos con cada cambio. aca es solo el inicio
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Provincias", connection);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            drpDownLstProvincia.DataSource = sqlDataReader;
            drpDownLstProvincia.DataTextField = "NombreProvincia";
            drpDownLstProvincia.DataValueField = "IdProvincia";
            drpDownLstProvincia.DataBind();
            drpDownLstProvincia.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
            sqlDataReader.Close();
            connection.Close();
        }

        protected DataTable cargarLocalidades(string IdProvincia)
            // carga localidades segun el parametro que le pasemos entonces funciona para cualquier drop down de localidades
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Localidades WHERE IdProvincia = @IdProvincia", connection); 
            connection.Open();

            sqlCommand.Parameters.AddWithValue("@IdProvincia", IdProvincia);

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dataTable);            
            
            connection.Close();
            
            return dataTable;
        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLocalidad.ClearSelection();
            dpProvinciaFinal.ClearSelection();
            ddlLocalidadFinal.ClearSelection(); 

            // cambio el drop down de localidad inicio:

            ddlLocalidad.DataSource = cargarLocalidades(drpDownLstProvincia.SelectedValue);
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();


            // cambio el drop down de provincia destino:

            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Provincias WHERE IdProvincia != @IdProvincia", connection);
            connection.Open();

            sqlCommand.Parameters.AddWithValue("@IdProvincia", drpDownLstProvincia.SelectedValue);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            dpProvinciaFinal.DataSource = sqlDataReader;
            dpProvinciaFinal.DataTextField = "NombreProvincia";
            dpProvinciaFinal.DataValueField = "IdProvincia";
            dpProvinciaFinal.DataBind();
            sqlDataReader.Close();
            connection.Close();


            //  cambio el drop down de localidad destino:

            ddlLocalidadFinal.DataSource = cargarLocalidades(dpProvinciaFinal.SelectedValue);
            ddlLocalidadFinal.DataTextField = "NombreLocalidad";
            ddlLocalidadFinal.DataValueField = "IdLocalidad";
            ddlLocalidadFinal.DataBind();

        }

        protected void ddlLocalidadInicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  cambio el drop down de localidad destino:

            ddlLocalidadFinal.DataSource = cargarLocalidades(dpProvinciaFinal.SelectedValue);
            ddlLocalidadFinal.DataTextField = "NombreLocalidad";
            ddlLocalidadFinal.DataValueField = "IdLocalidad";
            ddlLocalidadFinal.DataBind();

        }

        protected void ddlLocalidadDestinoIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
