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
    public partial class Imprimir_Factura : Form
    {
        public Imprimir_Factura()
        {
            InitializeComponent();
        }

        private void Imprimir_Factura_Load(object sender, EventArgs e)
        {

        }

        private void BTNagregar_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
    }
}
