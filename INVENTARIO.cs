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
using MySql.Data.MySqlClient;



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
            try
            {
                string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
                string consulta = "SELECT * FROM PRODUCTOS";

                using (MySqlConnection con = new MySqlConnection(cad_con))
                {
                    using (MySqlDataAdapter ad = new MySqlDataAdapter(consulta, con))
                    {
                        DataTable tab_Inven = new DataTable();
                        ad.Fill(tab_Inven);
                        DGV1.DataSource = tab_Inven;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message);
            }
        }
        private void CargarNombre(string filtro)
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

            // MySQL usa CHAR para el casting
            string query = @"SELECT CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, PRECIO, STOCK, CATEGORIA, FECHA_INGRESO
                     FROM PRODUCTOS
                     WHERE 
                         CAST(CODIGO AS CHAR) LIKE @filtro OR
                         NOMBRE_PRODUCTO LIKE @filtro OR
                         CATEGORIA LIKE @filtro";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cad_con))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                        // CORRECCIÓN: MySqlDataAdapter
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            DGV1.DataSource = dt;

                            foreach (DataRow row in dt.Rows)
                            {
                                // Aseguramos que el stock no sea nulo antes de convertir
                                if (row["STOCK"] != DBNull.Value)
                                {
                                    int stock = Convert.ToInt32(row["STOCK"]);
                                    string nombreP = row["NOMBRE_PRODUCTO"].ToString();

                                    if (stock <= 5)
                                    {
                                        MessageBox.Show($"Advertencia: {nombreP} se está agotando (Stock: {stock}).",
                                            "STOCK LIMITADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar datos: " + ex.Message);
            }
        }
        private void CargarCodigo(string filtro)
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

            // CORRECCIÓN: MySQL usa CHAR para el CAST
            string query = @"SELECT CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, PRECIO, STOCK, CATEGORIA, FECHA_INGRESO
                     FROM PRODUCTOS
                     WHERE 
                         CAST(CODIGO AS CHAR) LIKE @filtro";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cad_con))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                        // CORRECCIÓN: Nombre correcto MySqlDataAdapter
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            DGV1.DataSource = dt;

                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["STOCK"] != DBNull.Value)
                                {
                                    int stock = Convert.ToInt32(row["STOCK"]);
                                    string nombreP = row["NOMBRE_PRODUCTO"].ToString();

                                    if (stock <= 5)
                                    {
                                        MessageBox.Show($"Advertencia: {nombreP} tiene stock bajo ({stock}).",
                                            "STOCK LIMITADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por código: " + ex.Message);
            }
        }

        private void CargarCategoria()
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(cad_con))
            {
                string query = "SELECT DISTINCT CATEGORIA FROM PRODUCTOS ORDER BY CATEGORIA";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        // CAMBIO CLAVE: Cambiar SqlDataReader por MySqlDataReader
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbCategoria.Items.Clear();
                            while (reader.Read())
                            {
                                cmbCategoria.Items.Add(reader["CATEGORIA"].ToString());
                            }
                        }
                        // El conn.Close() no es estrictamente necesario aquí porque el 'using' lo hace solo
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar categorías: " + ex.Message);
                    }
                }
            }
        }

        private void CargarCat()
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (MySqlConnection con =new MySqlConnection (cad_con))
            {
                string query = @"select CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, PRECIO, STOCK, CATEGORIA, FECHA_INGRESO
                              from PRODUCTOS
                              where CATEGORIA =@CATEGORIA
                              ORDER BY CATEGORIA";
                using (MySqlCommand cmd =new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CATEGORIA", cmbCategoria.SelectedItem.ToString());
                    MySqlDataAdapter d = new MySqlDataAdapter(cmd); 
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

        private void label7_Click(object sender, EventArgs e)
        {
            Secciones secciones = new Secciones();
            secciones.ShowDialog();
            this.Hide();
        }

        private void BTNagregar_Click(object sender, EventArgs e)
        {

        }
    }
}
