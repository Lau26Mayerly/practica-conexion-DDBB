using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace practica_conexion_DDBB
{
    public partial class Form1 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
        public Form1()
        {
            InitializeComponent();

        }
        public static class Sesion
        {
            public static string Usuario;
            public static int Rol;
        }
        private void INGRESAR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TXTUSER.Text) ||
                string.IsNullOrWhiteSpace(TXTCLAVE.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña");
                return;
            }

            int idUsuario;

            if (!int.TryParse(TXTUSER.Text, out idUsuario))
            {
                MessageBox.Show("El usuario debe ser un número (ID)");
                return;
            }

            string clave = TXTCLAVE.Text;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(@"
                SELECT NOMBRE_U, ID_ROL
                FROM USUARIOS
                WHERE ID_USUARIO = @id
                AND CLAVE = @clave
                AND ESTADO = 'ACTIVO'", conn);

                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.Parameters.AddWithValue("@clave", clave);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Sesion.Usuario = reader["NOMBRE_U"].ToString();
                            Sesion.Rol = Convert.ToInt32(reader["ID_ROL"]);

                            RedirigirPorRol();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ID o contraseña incorrectos");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }
        private void RedirigirPorRol()
        {
            Form frm = null;

            switch (Sesion.Rol)
            {
                case 1:
                    frm = new Ventas();
                    break;

                case 2:
                    frm = new INVENTARIO();
                    break;

                case 3:
                    frm = new FacturasRealizadas();
                    break;

                case 4:
                    frm = new Secciones();
                    break;
                case 5:
                    frm = new Secciones();
                    break;
                default:
                    MessageBox.Show("Rol no autorizado");
                    return;
            }

            frm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TXTCLAVE.PasswordChar = '*';
        }
    }
}
