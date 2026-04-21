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
            fondo vn = new fondo();
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
    }
}
