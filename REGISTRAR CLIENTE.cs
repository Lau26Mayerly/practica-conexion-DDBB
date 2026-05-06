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
    public partial class REGISTRAR_CLIENTE : Form
    {
        bool cargandoDatos = false;
        public REGISTRAR_CLIENTE()
        {
            InitializeComponent();
        }

        private void BTNGUARDAR_Click(object sender, EventArgs e)
        {
            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(cad_con))
            {
                conn.Open();

                string sql = @"INSERT INTO Clientes
                  (CC,NOMBRE_CLIENTE,TELEFONO,DIRECCION)
                  VALUES
                  (@CC, @NOMBRE_CLIENTE, @TELEFONO, @DIRECCION)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CC", TXT_CC.Text);
                cmd.Parameters.AddWithValue("@NOMBRE_CLIENTE", TXT_Nombre.Text);
                cmd.Parameters.AddWithValue("@TELEFONO", TXT_Tel.Text);
                cmd.Parameters.AddWithValue("@DIRECCION", txt_Dir.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente registrado.");

                this.Close();
            }
        }
    }
}
