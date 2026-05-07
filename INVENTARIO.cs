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
        public string codigoSeleccionado = "";
        private void INVENTARIO_Load(object sender, EventArgs e)
        {
            CargarDatos();
            DGV1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DGV1.MultiSelect = false;
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
            Crear_Producto crear_Producto = new Crear_Producto();
            crear_Producto.Show();
            this.Hide();

        }

        private void BTNhabili_Click(object sender, EventArgs e)
        {
            ActualizarEstadoBD(1);
        }

        private void BTNinhab_Click(object sender, EventArgs e)
        {
            ActualizarEstadoBD(0);
        }
        private void CargarNombre(string filtro)
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

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

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DGV1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }
        private void TXTbuscar_TextChanged(object sender, EventArgs e)
        {
            CargarNombre(TXTbuscar.Text);
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                codigoSeleccionado = DGV1.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
            }
        }
      
        private void ActualizarEstadoBD(int nuevoEstado)
        {
            if (DGV1.CurrentRow == null || DGV1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Por favor, selecciona un producto de la lista primero.");
                return;
            }

            string codigoProd = DGV1.CurrentRow.Cells["CODIGO"].Value.ToString();
            if (DGV1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una fila completa en la tabla.");
                return;
            }
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            string query = "UPDATE PRODUCTOS SET ESTADO = @estado WHERE CODIGO = @codigo";

            try
            {
                using (MySqlConnection con = new MySqlConnection(cad_con))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@codigo", codigoProd);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            string mensaje = (nuevoEstado == 1) ? "Producto Habilitado" : "Producto Inhabilitado";
                            MessageBox.Show(mensaje + " correctamente en la base de datos.");
                            CargarDatos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la base de datos: " + ex.Message);
            }
        }
    }
}
