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
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection conec = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }

        void cargarTabla()
        {
            SqlCommand cdm = new SqlCommand("Cargar_Datos", conec);
            cdm.CommandType = CommandType.StoredProcedure;
            conec.Open();
            SqlDataAdapter da = new SqlDataAdapter(cdm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            TbEmpleados.DataSource = dt;
            TbEmpleados.DataBind();
            conec.Close();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string nombreBuscado = TxtSearch.Text.Trim();

            SqlCommand cmd = new SqlCommand("SELECT [Id_Empleado], [Nombre], [Apellido], [Correo], [Salario] FROM [Evoltis].[dbo].[Empleados] WHERE [Nombre] LIKE @Nombre", conec);
            cmd.Parameters.AddWithValue("@Nombre", "%" + nombreBuscado + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            TbEmpleados.DataSource = dt;
            TbEmpleados.DataBind();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Empleados.aspx?op=C");
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/Empleados.aspx?id=" + id + "&op=R");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/Empleados.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button BtnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)BtnDelete.NamingContainer;
            int id = Convert.ToInt32(row.Cells[1].Text);

            SqlCommand cmd = new SqlCommand("Borrar", conec);
            conec.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
            conec.Close();

            cargarTabla(); // Vuelve a cargar la tabla después de la eliminación
        }
    }
}