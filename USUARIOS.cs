using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_conexion_DDBB
{
    public partial class USUARIOS : Form
    {
        public USUARIOS()
        {
            InitializeComponent();
            CargarInfo();
        }
        private void CargarInfo()
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

            string consulta = "select * from USUARIOS";
            using (SqlConnection con = new SqlConnection(cad_con))
            {
                SqlDataAdapter ad = new SqlDataAdapter(consulta, con);
                DataTable tab_User = new DataTable();
                ad.Fill(tab_User);
                DGVuser.DataSource = tab_User;
            }
        }

        private void txtID_USER_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void CargarId(string filtro)
        {

            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cad_con))
            {
                string query = "select ID_USUARIO, NOMBRE_U, ID_ROL, CLAVE, ESTADO" +
                    "from USUARIOS" +
                    " WHERE  CAST(ID_USUARIO AS NVARCHAR) LIKE @filtro";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(@"filtro","%"+filtro+"%");
                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    DGVuser.DataSource = dt;
                }
            }
        }
        //comentado
        //private void CargarNombre(string filtro)
        //{

        //    string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(cad_con))
        //    {
        //        string query = "select ID_USUARIO, NOMBRE_U, ID_ROL, CLAVE, ESTADO" +
        //            "from USUARIOS" +
        //            " WHERE  NOMBRE_U = @filtro";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
        //            SqlDataAdapter d = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            d.Fill(dt);
        //            DGVuser.DataSource = dt;
        //        }
        //    }
        //}

        private void txtID_USER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarId(txtID_USER.Text.Trim());
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
               // CargarNombre(txtNombre.Text.Trim());
            }
        }

        private void USUARIOS_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Secciones secciones = new Secciones();
            secciones.Show();
            this.Hide();
        }
    }
}