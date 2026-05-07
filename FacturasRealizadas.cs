using System;
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
using MySql.Data.MySqlClient;

namespace practica_conexion_DDBB
{
    public partial class FacturasRealizadas : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

        public FacturasRealizadas()
        {
            InitializeComponent();
            ObtenerVentasRecientes();
        }

        private void DGVfacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        DataTable ObtenerVentasRecientes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ID_VENTA, FECHA, SUBTOTAL, IVA, VALOR, CLIENTE, VENDEDOR FROM FACTURAS ORDER BY FECHA DESC";


                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        // CORRECCIÓN: El nombre correcto es MySqlDataAdapter
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ventas: " + ex.Message);
            }

            return dt;
        }
        private void FacturasRealizadas_Load(object sender, EventArgs e)
        {
            DGVfacturas.DataSource = ObtenerVentasRecientes();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Secciones secciones = new Secciones();
            secciones.Show();
            this.Hide();
        }

        private void DGVfacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idVenta = Convert.ToInt32(
                    DGVfacturas.Rows[e.RowIndex].Cells["ID_VENTA"].Value
                );

                MostrarDetalleFactura(idVenta);
            }
        }
        private void MostrarDetalleFactura(int idVenta)
        {
            string query = @"
    SELECT 
        d.CODIGO_PRODUCTO,
        p.NOMBRE_PRODUCTO,
        d.CANTIDAD,
        d.PRECIO
    FROM DETALLE_FACTURA d
    INNER JOIN PRODUCTOS p
        ON d.CODIGO_PRODUCTO = p.CODIGO
    WHERE d.ID_VENTA = @IDVENTA";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDVENTA", idVenta);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DGVdetalle.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message);
            }
        }
    }
}
