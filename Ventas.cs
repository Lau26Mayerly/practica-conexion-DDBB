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
    public partial class Ventas : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
        bool cargandoDatos = false;
        bool productoAgregado = false;
        bool haySeleccionActiva = false;
        Control controlOrigen = null;
        public Ventas()
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
        int ObtenerStock(string codigo)
        {
            int stock = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT stock FROM productos WHERE codigo = @codigo", con);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    stock = Convert.ToInt32(dr["stock"]);
                }
            }

            return stock;
        }

        void RestarStock(string codigo, int cantidad)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE productos SET stock = stock - @cantidad WHERE codigo = @codigo", con);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
            }
        }
        void SumarStock(string codigo, int cantidad)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE productos SET stock = stock + @cantidad WHERE codigo = @codigo", con);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
            }
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
            //COLUMNAS DEL DATA GRID VIEW
            DGVventas.Columns.Clear();
            DGVventas.Columns.Add("Codigo", "Código");
            DGVventas.Columns.Add("Nombre", "Nombre");
            DGVventas.Columns.Add("Categoria", "Categoría");
            DGVventas.Columns.Add("Precio", "Precio");
            DGVventas.Columns.Add("Cantidad", "Cantidad");
            DGVventas.Columns.Add("Subtotal", "Subtotal");
            DGVventas.AllowUserToAddRows = false;
            // BOTON EN EL DATAGRID VIEW PARA ELIMINAR
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            btn.Name = "Eliminar";              // nombre interno
            btn.HeaderText = "Eliminar";        // texto arriba de la columna
            btn.Text = "X";                     // lo que aparece en cada botón
            btn.UseColumnTextForButtonValue = true;
            DGVventas.Columns.Add(btn);
        }
        private void btnComprar_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in DGVventas.Rows)
            {
                decimal precio = Convert.ToDecimal(fila.Cells["Precio"].Value);
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);

                total += precio * cantidad;
            }
            MessageBox.Show("Total a pagar: " + total.ToString("N0"));
            //Guardar la factura en BD
            DGVventas.Rows.Clear();
            MessageBox.Show("Venta registrada");
            
            }

            private void TXT_NIT_CLIENTE_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarNombreCliente();
            }

        }
        //BOTON ELIMINAR DENTRO DEL DATA GRID VIEW FUNCIONALIDAD
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DGVventas.CurrentRow != null)
            {
                DGVventas.Rows.Remove(DGVventas.CurrentRow);
            }
        }
        //BOTON AGREGAR
        private void BTNAGREGAR_Click(object sender, EventArgs e)
        {
            // VALIDAR CLIENTE
            if (!ClienteValido())
                return;
            // VALIDAR CAMPOS VACÍOS
            if (string.IsNullOrWhiteSpace(TXTCODIGO.Text) ||
                string.IsNullOrWhiteSpace(TXT_NOMBRE_P.Text) ||
                string.IsNullOrWhiteSpace(TXTCATEGORIA.Text) ||
                string.IsNullOrWhiteSpace(TXTPRECIO_P.Text) ||
                string.IsNullOrWhiteSpace(TXTCANTIDAD.Text))
            {
                MessageBox.Show("Debe seleccionar un producto válido.");
                return;
            }
            // VARIABLES
            string codigo = TXTCODIGO.Text;
            int cantidad;
            decimal precio;
            // VALIDAR DATOS
            if (!int.TryParse(TXTCANTIDAD.Text, out cantidad))
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }
            if (!decimal.TryParse(TXTPRECIO_P.Text, out precio))
            {
                MessageBox.Show("Precio inválido.");
                return;
            }
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.");
                return;
            }
            // OBTENER STOCK REAL DESDE BD
            int stockActual = ObtenerStock(codigo);

            if (cantidad > stockActual)
            {
                MessageBox.Show("No hay suficiente stock.");
                return;
            }

            //  DESCONTAR INVENTARIO
            RestarStock(codigo, cantidad);
            // CALCULAR SUBTOTAL
            decimal subtotal = precio * cantidad;
            // AGREGAR AL CARRITO
            DGVventas.Rows.Add(
                codigo,
                TXT_NOMBRE_P.Text,
                TXTCATEGORIA.Text,
                precio,
                cantidad,
                subtotal
            );

            // LIMPIAR CAMPOS
            LimpiarCampos();
            TXTCANTIDAD.Clear();
            TXTCODIGO.Focus();

            productoAgregado = true;
            haySeleccionActiva = false;
            //IMPORTANTE QUE EL CLIENTE SEA VALIDADO PARA FACTURA YA SEA TIPO RECIBO O ELECTRONICA
        }
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
        // ELIMINAR REGISTRO EN CASO DE QUE EL CLIENTE DESISTA DE LA COMPRA
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVventas.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                int cantidad = Convert.ToInt32(DGVventas.Rows[e.RowIndex].Cells["Cantidad"].Value);
                string codigo = DGVventas.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();

                //DEVOLVER STOCK
                SumarStock(codigo, cantidad);

                //ELIMINAR DEL CARRITO
                DGVventas.Rows.RemoveAt(e.RowIndex);
            }

        }
        //VALIDACIÓN DE FACTURAS RECIENTES
        DataTable ObtenerVentasRecientes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 10 * FROM FACTURAS ORDER BY FECHA DESC", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        private void BTNventasRecient_Click(object sender, EventArgs e)
        {
            //ventas recientes
            FacturasRealizadas frm = new FacturasRealizadas();
            frm.Show();
            DGVventas.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Secciones secciones = new Secciones();
            secciones.Show();
            this.Hide();
        }
    }
}





