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
    public partial class CLIENTES : Form
    {
        public bool ModoDesdeVentas = false;
        public CLIENTES()
        {
            InitializeComponent();
        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {

        }

        private void CLIENTES_Load(object sender, EventArgs e)
        {
           
        }

        private void BTNCREAR_Click(object sender, EventArgs e)
        {
            REGISTRAR_CLIENTE r = new REGISTRAR_CLIENTE();
            r.Show();
        }
    }
}
