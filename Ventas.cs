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

namespace practica_conexion_DDBB
{
    public partial class fondo : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
        bool cargandoDatos = false;
        public fondo()
        {
            InitializeComponent();
            TXTCLIENTE.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //OCULTAR LISTBOX AL INICIAR 
            listBoxProductos.Visible = false;
            TXTCODIGO.KeyDown += TXTCODIGO_KeyDown;
            TXTCODIGO.TextChanged += TXTCODIGO_TextChanged;
        }
        //     private void BuscarNombreCliente()
        //     {
        //         string query =
        //@"SELECT NOMBRE_CLIENTE
        //  FROM CLIENTES
        //  WHERE CC=@CC";

        //         using (SqlConnection conn =
        //         new SqlConnection(connectionString))
        //         {
        //             conn.Open();

        //             SqlCommand cmd =
        //             new SqlCommand(query, conn);

        //             int cc;

        //             if (!int.TryParse(TXTCLIENTE.Text.Trim(), out cc))
        //             {
        //                 MessageBox.Show("CC inválida");
        //                 return;
        //             }

        //             cmd.Parameters.AddWithValue("@CC", cc);

        //             object resultado =
        //             cmd.ExecuteScalar();

        //             if (resultado != null)
        //             {
        //                 TXTCLIENTE.Text =
        //                 resultado.ToString();
        //             }
        //             else
        //             {
        //                 MessageBox.Show("Cliente no existe");
        //             }

        //         }

        //     }

        private void BuscarNombreCliente()
        {
            int cc;

            if (!int.TryParse
            (TXT_NIT_CLIENTE.Text, out cc))
            {
                MessageBox.Show("CC inválida");
                return;
            }
            string query =
            @"SELECT NOMBRE_CLIENTE
      FROM CLIENTES
      WHERE CC=@CC";
            using (SqlConnection conn =
            new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CC", cc);
                object resultado =
                cmd.ExecuteScalar();
                if (resultado != null)
                {
                    TXTCLIENTE.Text =
                    resultado.ToString();
                }
                else
                {
                    DialogResult r = MessageBox.Show(
                        "Cliente no existe. ¿Desea crearlo?",
                        "Nuevo Cliente",
                        MessageBoxButtons.YesNo);

                    if (r == DialogResult.Yes)
                    {
                        CLIENTES frm = new CLIENTES();
                        frm.ShowDialog();
                    }
                    else if (r == DialogResult.No)
                    {
                        TXTCLIENTE.Text = "CLIENTE DE MOSTRADOR";
                        TXT_NIT_CLIENTE.Text = "222222222222";


                    }
                }

            }

        }
        private void BuscarPorCodigo()
        {
            int cod;
            if (!int.TryParse(TXTCODIGO.Text, out cod))
            {
                MessageBox.Show("Código inválido");
                return;
            }
            BuscarYCompletar(
            "WHERE CODIGO=@valor",
            cod.ToString());

        }
        private void BuscarYCompletar
              (string whereSql, string valor)
        {
            string query = $@"

              SELECT CODIGO,  NOMBRE_PRODUCTO, CATEGORIA, PRECIO,STOCK FROM PRODUCTOS {whereSql}";


            using (SqlConnection conn =
            new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd =
                new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue
                ("@valor", valor);

                SqlDataReader reader =
                cmd.ExecuteReader();

                if (reader.Read())
                {
                    TXTCODIGO.Text =
                    reader["CODIGO"].ToString();

                    TXT_NOMBRE_P.Text =
                    reader["NOMBRE_PRODUCTO"].ToString();

                    TXTCATEGORIA.Text = reader["CATEGORIA"].ToString();

                    TXTPRECIO_P.Text =
                    reader["PRECIO"].ToString();

                    TXTSTOCK.Text =
                    reader["STOCK"].ToString();
                }

            }

        }
        private void BuscarCoincidencias(string campo, string valor)
        {
            string query;

            if (campo == "CODIGO")
            {
                query = @"
        SELECT CODIGO, NOMBRE_PRODUCTO
        FROM PRODUCTOS
        WHERE CAST(CODIGO AS VARCHAR) LIKE @valor";
            }
            else
            {
                query = $@"
        SELECT CODIGO, NOMBRE_PRODUCTO
        FROM PRODUCTOS
        WHERE {campo} LIKE @valor";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> lista = new List<string>();

                while (reader.Read())
                {
                    lista.Add(
                        reader["CODIGO"].ToString()
                        + " - " +
                        reader["NOMBRE_PRODUCTO"].ToString()
                    );
                }

                listBoxProductos.DataSource = lista;
                listBoxProductos.Visible = lista.Count > 0;
            }

        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            int codigo =
           Convert.ToInt32
           (TXTCODIGO.Text);
            int cliente =
            Convert.ToInt32
            (TXTCLIENTE.Text);
            int cantidad =
            Convert.ToInt32
            (TXTCANTIDAD.Text);
            int vendedor = 1;
            Ventaslogica venta = new Ventaslogica();
            bool ok =
            venta.RegistrarVenta
            (
             codigo,
             cliente,
             vendedor,
             cantidad
            );


            if (ok)
            {
                MessageBox.Show
                ("Venta registrada");
            }

        }




        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void TXT_NIT_CLIENTE_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TXT_NIT_CLIENTE_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarNombreCliente();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(TXTCANTIDAD.Text);
            int existencias = int.Parse(TXTSTOCK.Text);

            if (cantidad > existencias)
            {
                MessageBox.Show("No hay suficiente stock.");
                return;
            }
        }

        private void TXTCODIGO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // BuscarPorCodigo();
            }
        }

        private void TXT_NOMBRE_P_TextChanged(object sender, EventArgs e)
        {
            BuscarCoincidencias
               ("NOMBRE_PRODUCTO",
               TXT_NOMBRE_P.Text);
        }

        private void TXTCATEGORIA_TextChanged(object sender, EventArgs e)
        {

            BuscarCoincidencias(
             "CATEGORIA",
              TXTCATEGORIA.Text);
        }

        private void TXTCODIGO_TextChanged(object sender, EventArgs e)
        {
            if (cargandoDatos) return;

            BuscarCoincidencias(
            "CODIGO",
            TXTCODIGO.Text);
        }

        private void listBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void listBoxProductos_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxProductos.SelectedItem != null)
            {
                string item =
                listBoxProductos.SelectedItem.ToString();

                string codigo =
                item.Split('-')[0].Trim();

                BuscarYCompletar(
                "WHERE CODIGO=@valor",
                codigo);

                listBoxProductos.Visible = false;
            }
        }

        private void TXTCANTIDAD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TXTCANTIDAD.Text) ||
       string.IsNullOrWhiteSpace(TXTSTOCK.Text))
                return;

            int cantidad;
            int existencias;

            if (int.TryParse(TXTCANTIDAD.Text, out cantidad) &&
                int.TryParse(TXTSTOCK.Text, out existencias))
            {
                if (cantidad > existencias)
                {
                    MessageBox.Show(
                        "La cantidad ingresada supera las existencias disponibles.",
                        "Stock insuficiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    TXTCANTIDAD.Focus();
                    TXTCANTIDAD.SelectAll(); 
                }
            }
        }
    }
}





