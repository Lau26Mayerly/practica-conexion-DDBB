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
        bool productoAgregado = false;
        bool haySeleccionActiva = false;
        Control controlOrigen = null;
        public fondo()
        {
            InitializeComponent();
            TXTCLIENTE.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //OCULTAR LISTBOX AL INICIAR 
            listBoxProductos.Visible = false;
            TXTCODIGO.KeyDown += TXTCODIGO_KeyDown;
            TXTCODIGO.TextChanged += TXTCODIGO_TextChanged;
            TXTCODIGO.TextChanged += TextBoxBusqueda_TextChanged;
            TXTCATEGORIA.TextChanged += TextBoxBusqueda_TextChanged;
        }
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
            DGV1.Columns.Clear();

            DGV1.Columns.Add("Codigo", "Código");
            DGV1.Columns.Add("Nombre", "Nombre");
            DGV1.Columns.Add("Categoria", "Categoría");
            DGV1.Columns.Add("Precio", "Precio");
            DGV1.Columns.Add("Cantidad", "Cantidad");
            DGV1.Columns.Add("Subtotal", "Subtotal");

            DGV1.AllowUserToAddRows = false;
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
        private void TXT_NIT_CLIENTE_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarNombreCliente();
            }

        }

        //BOTON AGREGAR
        private void BTNAGREGAR_Click(object sender, EventArgs e)
        {
            //VALIDAR CLIENTE
            if (!ClienteValido())
            {
                return;
            }
            //VALIDAR ESPACIOS VACIOS Y RETORNAR
            if (string.IsNullOrWhiteSpace(TXTCODIGO.Text) ||
                string.IsNullOrWhiteSpace(TXT_NOMBRE_P.Text) ||
                string.IsNullOrWhiteSpace(TXTCATEGORIA.Text) ||
                string.IsNullOrWhiteSpace(TXTPRECIO_P.Text))
            {
                MessageBox.Show("Debe seleccionar un producto válido.");
                return;
            }

            //VALIDAR NUMEROS
            int codigo, cantidad,stock;
            decimal precio;

            if (!int.TryParse(TXTCODIGO.Text, out codigo))
            {
                MessageBox.Show("Código inválido.");
                return;
            }

            if (!decimal.TryParse(TXTPRECIO_P.Text, out precio))
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            if (!int.TryParse(TXTCANTIDAD.Text, out cantidad))
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            if (!int.TryParse(TXTSTOCK.Text, out stock))
            {
                MessageBox.Show("Stock inválido.");
                return;
            }
            // VALIDAR CANTIDAD
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.");
                return;
            }
            if (cantidad > stock)
            {
                MessageBox.Show("No hay suficiente stock.");
                return;
            }
            //  CALCULAR SUBTOTAL
            decimal subtotal = precio * cantidad;
            //  AGREGAR AL CARRITO TEMPORAL
            DGV1.Rows.Add(
                codigo,
                TXT_NOMBRE_P.Text,
                TXTCATEGORIA.Text,
                precio,
                cantidad,
                subtotal
            );
            // MARCAR COMO AGREGADO
            productoAgregado = true;
            haySeleccionActiva = false;

            //LIMPIAR PARA SIGUIENTE PRODUCTO
            LimpiarCampos();
            TXTCANTIDAD.Clear();

            TXTCODIGO.Focus();
        }
        //IMPORTANTE QUE EL CLIENTE SEA VALIDADO PARA FACTURA YA SEA TIPO RECIBO O ELECTRONICA
        private bool ClienteValido()
        {
            string documento = TXT_NIT_CLIENTE.Text.Trim();

            if (documento == "222222222222")
            {
                return true;
            }
            if (string.IsNullOrWhiteSpace(documento))
            {
                MessageBox.Show("Debe ingresar CC o NIT del cliente.");
                return false;
            }
            string query = "SELECT COUNT(*) FROM CLIENTES WHERE CC = @CC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CC", documento);

                int existe = (int)cmd.ExecuteScalar();

                if (existe == 0)
                {
                    MessageBox.Show("El cliente no está registrado.");
                    return false;
                }
            }

            return true;
        }

        private void TXTCODIGO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void TXT_NOMBRE_P_TextChanged(object sender, EventArgs e)
        {
            if (cargandoDatos) return;

            Control actual = sender as Control;
            if (haySeleccionActiva && !productoAgregado && actual != controlOrigen)
            {
                LimpiarCampos();
                return;
            }
            BuscarCoincidencias(
                "NOMBRE_PRODUCTO",
                TXT_NOMBRE_P.Text
            );
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
                string item = listBoxProductos.SelectedItem.ToString();
                string codigo = item.Split('-')[0].Trim();

                BuscarYCompletar("WHERE CODIGO=@valor", codigo);

                listBoxProductos.Visible = false;

                haySeleccionActiva = true;
                productoAgregado = false;
                controlOrigen = GetControlActivo();
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

        private void listBoxProductos_Click(object sender, EventArgs e)
        {
        }
        private void TextBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (cargandoDatos) return;
            Control actual = sender as Control;
            if (haySeleccionActiva && !productoAgregado && actual != controlOrigen)
            {
                LimpiarCampos();
            }
        }
        private Control GetControlActivo()
        {
            if (TXTCODIGO.Focused) return TXTCODIGO;
            if (TXT_NOMBRE_P.Focused) return TXT_NOMBRE_P;
            if (TXTCATEGORIA.Focused) return TXTCATEGORIA;

            return null;
        }
        private void LimpiarCampos()
        {
            cargandoDatos = true;

            TXTCODIGO.Clear();
            TXT_NOMBRE_P.Clear();
            TXTCATEGORIA.Clear();
            TXTPRECIO_P.Clear();
            TXTSTOCK.Clear();

            listBoxProductos.Visible = false;

            haySeleccionActiva = false;
            productoAgregado = false;
            controlOrigen = null;

            cargandoDatos = false;
        }
    }
}





