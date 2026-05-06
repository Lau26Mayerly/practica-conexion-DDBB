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
    public partial class Crear_Producto : Form
    {
        private string connectionString = ConfigurationManager
    .ConnectionStrings["CONEXION"].ConnectionString;
        public Crear_Producto()
        {
            InitializeComponent();
        }

        private void BTNagregar_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(TXTPRECIO.Text) ||
                string.IsNullOrWhiteSpace(TXTCANT.Text))
            {
                MessageBox.Show("Complete los campos obligatorios");
                return;
            }
            int codigo, stock;
            decimal precio;

            if (!int.TryParse(txtCodigo.Text, out codigo))
            {
                MessageBox.Show("Código inválido");
                return;
            }

            if (!decimal.TryParse(TXTPRECIO.Text, out precio))
            {
                MessageBox.Show("Precio inválido");
                return;
            }

            if (!int.TryParse(TXTCANT.Text, out stock))
            {
                MessageBox.Show("Stock inválido");
                return;
            }
            if (string.IsNullOrWhiteSpace(CMBestado.Text))
            {
                MessageBox.Show("Seleccione el estado del producto");
                return;
            }
            if (string.IsNullOrWhiteSpace(TXTCATEG.Text))
            {
                MessageBox.Show("Ingrese la categoría");
                return;
            }
            if (stock < 0)
            {
                MessageBox.Show("El stock no puede ser nulo o negativo");
                return;
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string validar = "SELECT COUNT(*) FROM PRODUCTOS WHERE CODIGO=@CODIGO";
                    MySqlCommand cmdValidar = new MySqlCommand(validar, conn);
                    cmdValidar.Parameters.AddWithValue("@CODIGO", codigo);

                    int existe = Convert.ToInt32(cmdValidar.ExecuteScalar());

                    if (existe > 0)
                    {
                        MessageBox.Show("El producto ya existe.");
                        return;
                    }

                    string query = @"
            INSERT INTO PRODUCTOS
            (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, PRECIO, STOCK, CATEGORIA, FECHA_INGRESO, ESTADO)
            VALUES
            (@CODIGO, @NOMBRE, @DESC, @PRECIO, @STOCK, @CATEGORIA, @FECHA, @ESTADO)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    cmd.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@DESC", TXTDESCRIP.Text);
                    cmd.Parameters.AddWithValue("@PRECIO", precio);
                    cmd.Parameters.AddWithValue("@STOCK", stock);
                    cmd.Parameters.AddWithValue("@CATEGORIA", TXTCATEG.Text);
                    cmd.Parameters.AddWithValue("@FECHA", DTP1.Value);
                    cmd.Parameters.AddWithValue("@ESTADO", CMBestado.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Producto registrado correctamente");

                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            TXTDESCRIP.Clear();
            TXTPRECIO.Clear();
            TXTCANT.Clear();
            TXTCATEG.Clear();
            CMBestado.SelectedIndex = -1;
        }

    }
}
