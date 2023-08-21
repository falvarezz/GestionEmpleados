using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GestionEmpleados.Pages
{
    public partial class Empleados : System.Web.UI.Page
    {
        readonly SqlConnection conec = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string eID = "-1";
        public static string eOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    eID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    eOpc = Request.QueryString["op"].ToString();
                    switch (eOpc)
                    {
                        case "C":
                            this.lbtitulo.Text = "Registrar nuevo Empleado";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbtitulo.Text = "Consulta de Empleado";
                            break;
                        case "U":
                            this.lbtitulo.Text = "Modificar Empleado";
                            this.BtnUpdate.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            conec.Open();
            SqlDataAdapter da = new SqlDataAdapter("Leer", conec);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = eID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            TbNombre.Text = row[1].ToString();
            TbApellido.Text = row[2].ToString();
            TbEmail.Text = row[3].ToString();
            TbSalario.Text = row[4].ToString();
            conec.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Crear", conec);
            conec.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = TbNombre.Text; ;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = TbApellido.Text; ;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = TbEmail.Text; ;
            cmd.Parameters.Add("@Salario", SqlDbType.Int).Value = TbSalario.Text; ;
            cmd.ExecuteNonQuery();
            conec.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Editar", conec);
            conec.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = eID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = TbNombre.Text; ;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = TbApellido.Text; ;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = TbEmail.Text; ;
            cmd.Parameters.Add("@Salario", SqlDbType.Int).Value = TbSalario.Text; ;
            cmd.ExecuteNonQuery();
            conec.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}