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

namespace practica_conexion_DDBB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }

        }
        string connectionString = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
        private void ENCRIPTAR_Click(object sender, EventArgs e)
        {
            Secciones S = new Secciones();
            S.Show();
            this.Hide();
            List<(int idUsuario, string clave)> usuarios = new List<(int, string)>();

            // Leer usuarios
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID_USUARIO, CLAVE FROM USUARIOS", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string clave = reader.GetString(1);
                    usuarios.Add((id, clave));
                }
            }
    


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
