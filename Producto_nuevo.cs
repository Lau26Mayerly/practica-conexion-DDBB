using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_conexion_DDBB
{
    public partial class Producto_nuevo : Form
    {
        public Producto_nuevo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Dir_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXT_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TXT_Tel_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXT_CC_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNGUARDAR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_Codigo.Text) || string.IsNullOrEmpty(TXT_Nombre.Text) || string.IsNullOrEmpty(TXT_precio.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (Código, Nombre, Precio).");
                return;
            }

            string cad_con = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;

            
            string query = @"INSERT INTO PRODUCTOS 
                     (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, PRECIO, STOCK, CATEGORIA, FECHA_INGRESO, ESTADO) 
                     VALUES 
                     (@codigo, @nombre, @desc, @precio, @stock, @cat, NOW(), 1)";

            try
            {
                using (MySqlConnection con = new MySqlConnection(cad_con))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        // 3. Pasamos los parámetros desde tus TextBox o ComboBox
                        cmd.Parameters.AddWithValue("@codigo", TXT_Codigo.Text);
                        cmd.Parameters.AddWithValue("@nombre", TXT_Nombre.Text);
                        cmd.Parameters.AddWithValue("@desc", txt_Descrip.Text);
                        cmd.Parameters.AddWithValue("@precio", decimal.Parse(TXT_precio.Text));
                        cmd.Parameters.AddWithValue("@stock", int.Parse(TXTstock.Text));
                        cmd.Parameters.AddWithValue("@cat", CMBcateg.Text);

                        int resultado = cmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Producto creado exitosamente.");
                            LimpiarCampos(); 
                              
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    MessageBox.Show("El código de producto ya existe.");
                else
                    MessageBox.Show("Error de base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
       
        private void LimpiarCampos()
        {
            TXT_Codigo.Clear();
            TXT_Nombre.Clear();
            txt_Descrip.Clear();
            TXT_precio.Clear();
            TXTstock.Clear();
            CMBestado.SelectedIndex = -1;
            CMBcateg.SelectedIndex = -1;
        }
    }
}
