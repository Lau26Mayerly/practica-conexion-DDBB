using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
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


        public DataTable ObtenerDatosFacturaCompleta(string idVenta)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT f.FECHA, f.VALOR as TOTAL_FACTURA, 
               c.CC, c.NOMBRE_CLIENTE, 
               u.ID_USUARIO, u.NOMBRE_U as NOMBRE_VENDEDOR,
               p.NOMBRE_PRODUCTO, d.CANTIDAD, d.PRECIO, 
               (d.CANTIDAD * d.PRECIO) as TOTAL_LINEA 
        FROM facturas f
        JOIN clientes c ON f.CLIENTE = c.CC
        JOIN usuarios u ON f.VENDEDOR = u.ID_USUARIO
        JOIN detalle_factura d ON f.ID_VENTA = d.ID_VENTA
        JOIN productos p ON d.CODIGO_PRODUCTO = p.CODIGO
        WHERE f.ID_VENTA = @id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idVenta);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        private void BTNagregar_Click(object sender, EventArgs e)
        {
            if (DGVfacturas.CurrentRow == null) return;

            string idVenta = DGVfacturas.CurrentRow.Cells[0].Value.ToString();

            DataTable datos = ObtenerDatosFacturaCompleta(idVenta);
            if (datos.Rows.Count == 0) return;

            DataRow fila = datos.Rows[0]; 
            double totalFactura = Convert.ToDouble(fila["TOTAL_FACTURA"]);
            double subtotalGlobal = totalFactura / 1.19;
            double ivaGlobal = totalFactura - subtotalGlobal;

            StringBuilder html = new StringBuilder();
            html.Append("<html><head><style>");
            html.Append("body { font-family: Arial, sans-serif; margin: 30px; font-size: 14px; }");
            html.Append(".header { width: 100%; border-bottom: 2px solid #333; margin-bottom: 20px; }");
            html.Append("table { width: 100%; border-collapse: collapse; margin-top: 10px; }");
            html.Append("th, td { border: 1px solid #ccc; padding: 10px; text-align: left; }");
            html.Append("th { background-color: #f8f8f8; }");
            html.Append(".totales-box { float: right; width: 250px; margin-top: 20px; }");
            html.Append(".totales-box div { display: flex; justify-content: space-between; padding: 5px 0; }");
            html.Append("</style></head><body>");

            // ENCABEZADO
            html.Append("<div class='header'>");
            html.Append("<h1 style='text-align:center;'>FACTURA ELECTRÓNICA</h1>");
            html.Append($"<p><b>No. Factura:</b> {idVenta} &nbsp;&nbsp;&nbsp; <b>Fecha:</b> {fila["FECHA"]}</p>");
            html.Append("<hr>");
            html.Append($"<p><b>CLIENTE:</b> {fila["NOMBRE_CLIENTE"]}<br><b>CC:</b> {fila["CC"]}</p>");
          
            html.Append($"<p><b>VENDEDOR:</b> {fila["NOMBRE_VENDEDOR"]}<br><b>ID:</b> {fila["ID_USUARIO"]}</p>");
            html.Append("</div>");
            
            html.Append("<table><tr><th>Producto</th><th>Cant.</th><th>Subtotal</th><th>IVA (19%)</th><th>Total</th></tr>");

            foreach (DataRow row in datos.Rows)
            {
                double tLinea = Convert.ToDouble(row["TOTAL_LINEA"]);
                double sLinea = tLinea / 1.19;
                double iLinea = tLinea - sLinea;

                html.Append("<tr>");
                html.Append($"<td>{row["NOMBRE_PRODUCTO"]}</td>");
                html.Append($"<td>{row["CANTIDAD"]}</td>");
                html.Append($"<td>${sLinea:N2}</td>");
                html.Append($"<td>${iLinea:N2}</td>");
                html.Append($"<td>${tLinea:N2}</td>");
                html.Append("</tr>");
            }
            html.Append("</table>");

            // BLOQUE DE TOTALES FINAL
            html.Append("<div class='totales-box'>");
            html.Append($"<div><span>Subtotal:</span> <span>${subtotalGlobal:N2}</span></div>");
            html.Append($"<div><span>IVA (19%):</span> <span>${ivaGlobal:N2}</span></div>");
            html.Append($"<div style='font-weight:bold; border-top:1px solid #333;'><span>TOTAL:</span> <span>${totalFactura:N2}</span></div>");
            html.Append("</div>");

            html.Append("</body></html>");

            // 4. Mostrar en el visor
            Imprimir_Factura visor = new Imprimir_Factura();
            visor.webBrowser1.DocumentText = html.ToString();
            visor.ShowDialog();
        }
    }
}
