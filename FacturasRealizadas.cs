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

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM FACTURAS ORDER BY FECHA DESC", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
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
