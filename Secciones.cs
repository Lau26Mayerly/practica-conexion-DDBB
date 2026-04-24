using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_conexion_DDBB
{
    public partial class Secciones : Form
    {
        public Secciones()
        {
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas vn = new Ventas();
            vn.Show();
            this.Hide();

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            INVENTARIO INV = new INVENTARIO();
            INV.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            USUARIOS us = new USUARIOS();
            us.Show();
            this.Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CLIENTES cl = new CLIENTES();
            cl.Show();  
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show( "¿Estás seguro de que deseas regresar?",
                 "Confirmación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Form1 F= new Form1();
                F.Show();
                this.Close(); // O tu lógica para volver atrás
            }
            
        }
    }
}
