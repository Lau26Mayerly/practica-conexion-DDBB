using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_conexion_DDBB
{
    internal class ModificarProducto
    {
        private int Codigo_producto { get; set; }
        private string Nombre_producto { get; set; }
        private string Descrip_producto { get; set; }
        private decimal Precio_producto { get; set; }
        private int Stock_producto { get; set; }

        public ModificarProducto()
        {

        }
        public ModificarProducto(int id_producto, string Nproducto, string Descproducto, decimal precioproducto, int stockproducto)
        {
            this.Codigo_producto=id_producto;
            this.Nombre_producto=Nproducto;
            this.Descrip_producto=Descproducto;
            this.Precio_producto=precioproducto;
            this.Stock_producto=stockproducto;
        }
    }


}
