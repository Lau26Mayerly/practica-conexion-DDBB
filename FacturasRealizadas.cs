using System;
using System.Configuration;
using System.Data;
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
        }

        private void FacturasRealizadas_Load(object sender, EventArgs e)
        {
            CargarVentasPrincipales();
        }

        void CargarVentasPrincipales()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            f.ID_VENTA, 
                            f.FECHA, 
                            c.NOMBRE_CLIENTE AS CLIENTE, 
                            f.SUBTOTAL, 
                            f.IVA, 
                            f.VALOR, 
                            f.VENDEDOR 
                        FROM FACTURAS f
                        INNER JOIN CLIENTES c ON f.CLIENTE = c.CC
                        ORDER BY f.FECHA DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGVfacturas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ventas: " + ex.Message);
            }
        }
        private void DGVfacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var valorId = DGVfacturas.Rows[e.RowIndex].Cells["ID_VENTA"].Value;

                if (valorId != null)
                {
                    string idVenta = valorId.ToString();
                    LBnumeroFact.Text = "FACTURA N°: " + idVenta;
                    CargarDetalleFactura(idVenta);
                }
            }
        }
        private void CargarDetalleFactura(string idVenta)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Incluimos los cálculos que pediste por cada producto
                    string query = @"
                        SELECT 
                            CODIGO_PRODUCTO, 
                            CANTIDAD, 
                            PRECIO AS PRECIO_UNIT,
                            (CANTIDAD * PRECIO) AS SUBTOTAL,
                            (CANTIDAD * PRECIO * 0.19) AS IVA_19,
                            (CANTIDAD * PRECIO * 1.19) AS TOTAL_LINEA
                        FROM DETALLE_FACTURA 
                        WHERE ID_VENTA = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idVenta);

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    DGVdetalle.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Ventas v = new Ventas();
            v.Show();
            this.Hide();
        }
    }
}
