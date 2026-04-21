using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;



namespace practica_conexion_DDBB
{
    public partial class INVENTARIO : Form
    {
        public INVENTARIO()
        {
            InitializeComponent();
        }

        private void INVENTARIO_Load(object sender, EventArgs e)
        {

            //string cad_con = "CONEXION";
            CargarDatos();
            CargarCategoria();

        }
        private void CargarDatos()
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

            string consulta = "select * from PRODUCTOS";
            using (SqlConnection con = new SqlConnection(cad_con))
            {
                SqlDataAdapter ad = new SqlDataAdapter(consulta, con);
                DataTable tab_Inven = new DataTable();
                ad.Fill(tab_Inven);
                DGV1.DataSource = tab_Inven;
            }
        }

       
        private void CargarNombre(string filtro)
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cad_con))

            {
                
                string query = @"SELECT CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, PRECIO, STOCK, CATEGORIA, FECHA_INGRESO
                             FROM Productos
                             WHERE 
                                 CAST(CODIGO AS NVARCHAR) LIKE @filtro OR
                                 NOMBRE_PRODUCTO LIKE @filtro OR
                                 CATEGORIA LIKE @filtro";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGV1.DataSource = dt;
                    foreach (DataRow row in dt.Rows)
                    {
                        int Stock = Convert.ToInt32(row["STOCK"]);
                        string Nombre_p = row["NOMBRE_PRODUCTO"].ToString();
                        if (Stock <= 5)
                        {
                            MessageBox.Show($"Advertencia: " + Nombre_p + " se esta agotando, ¿Deseas enviar alerta?", "STOCK LIMITADO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                    }

                }
            }
        }
        private void CargarCodigo(string filtro)
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cad_con))

            {

                string query = @"SELECT CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, PRECIO, STOCK, CATEGORIA, FECHA_INGRESO
                             FROM Productos
                             WHERE 
                                 CAST(CODIGO AS NVARCHAR) LIKE @filtro";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGV1.DataSource = dt;
                    foreach (DataRow row in dt.Rows)
                    {
                        int Stock = Convert.ToInt32(row["STOCK"]);
                        string Nombre_p = row["NOMBRE_PRODUCTO"].ToString();
                        if (Stock <= 5)
                        {
                            MessageBox.Show($"Advertencia: " + Nombre_p + " se esta agotando, ¿Deseas enviar alerta?", "STOCK LIMITADO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                    }

                }
            }
        }


        private void CargarCategoria()
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cad_con))

            {

                string query = "SELECT DISTINCT CATEGORIA FROM PRODUCTOS ORDER BY CATEGORIA";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmbCategoria.Items.Clear();
                    while (reader.Read())
                    {
                        cmbCategoria.Items.Add(reader["CATEGORIA"].ToString());

                    }
                    conn.Close();                   
                }
            }
        }
        private void CargarCat()
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection con =new SqlConnection (cad_con))
            {
                string query = @"select CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, PRECIO, STOCK, CATEGORIA, FECHA_INGRESO
                              from PRODUCTOS
                              where CATEGORIA =@CATEGORIA
                              ORDER BY CATEGORIA";
                using (SqlCommand cmd =new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CATEGORIA", cmbCategoria.SelectedItem.ToString());
                    SqlDataAdapter d = new SqlDataAdapter(cmd); 
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    DGV1 .DataSource = dt;
                    foreach (DataRow row in dt.Rows)
                    {
                        int Stock= Convert.ToInt32(row["STOCK"]);
                        string Nombre_p = row["NOMBRE_PRODUCTO"].ToString();
                        if (Stock <= 5 ) 
                        {
                            MessageBox.Show($"Advertencia: "+ Nombre_p +" se esta agotando, ¿Deseas enviar alerta?","STOCK LIMITADO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                    }
                   
                }
            }
        }
        private void txtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarCategoria();
            }
        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                CargarNombre(txtNombre.Text.Trim());
            }
        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarCodigo(txtCodigo.Text.Trim());
            }
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CATEGORIA =cmbCategoria.SelectedItem.ToString();
            CargarCat();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
