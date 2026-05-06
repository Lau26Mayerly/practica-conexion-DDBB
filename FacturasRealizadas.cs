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

                    // Consulta para obtener las facturas más recientes
                    string query = "SELECT * FROM FACTURAS ORDER BY FECHA DESC";

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
    }
}
