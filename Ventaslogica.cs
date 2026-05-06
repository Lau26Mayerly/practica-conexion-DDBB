using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace practica_conexion_DDBB
{
    public class Ventaslogica
    {

        string connectionString =
        ConfigurationManager
        .ConnectionStrings["CONEXION"]
        .ConnectionString;

        public bool RegistrarVenta(int codigoProducto, int cliente, int vendedor, int cantidad)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Obtener precio
                    decimal precio = Convert.ToDecimal(new MySqlCommand(
                        "SELECT PRECIO FROM PRODUCTOS WHERE CODIGO=@CODIGO",
                        conn, tran)
                    {
                        Parameters = { new MySqlParameter("@CODIGO", codigoProducto) }
                    }.ExecuteScalar());

                    decimal subtotal = precio * cantidad;
                    decimal iva = subtotal * 0.19m;
                    decimal total = subtotal + iva;

                    // Insertar factura
                    new MySqlCommand(@"
                INSERT INTO FACTURAS (FECHA, SUBTOTAL, IVA, VALOR, DETALLE, CLIENTE, VENDEDOR)
                VALUES (NOW(), @SUBTOTAL, @IVA, @TOTAL, @DETALLE, @CLIENTE, @VENDEDOR)",
                        conn, tran)
                    {
                        Parameters =
                {
                    new MySqlParameter("@SUBTOTAL", subtotal),
                    new MySqlParameter("@IVA", iva),
                    new MySqlParameter("@TOTAL", total),
                    new MySqlParameter("@DETALLE", codigoProducto),
                    new MySqlParameter("@CLIENTE", cliente),
                    new MySqlParameter("@VENDEDOR", vendedor)
                }
                    }.ExecuteNonQuery();

                    // Actualizar stock
                    new MySqlCommand(@"
                UPDATE PRODUCTOS 
                SET STOCK = STOCK - @CANTIDAD 
                WHERE CODIGO = @CODIGO",
                        conn, tran)
                    {
                        Parameters =
                {
                    new MySqlParameter("@CANTIDAD", cantidad),
                    new MySqlParameter("@CODIGO", codigoProducto)
                }
                    }.ExecuteNonQuery();

                    // Registrar rotación
                    new MySqlCommand(@"
                INSERT INTO VENTA_ROTACION (ID_PRODUCTO, CANTIDAD, FECHA, ESTADO)
                VALUES (@CODIGO, @CANTIDAD, NOW(), 'VENTA')",
                        conn, tran)
                    {
                        Parameters =
                {
                    new MySqlParameter("@CODIGO", codigoProducto),
                    new MySqlParameter("@CANTIDAD", cantidad)
                }
                    }.ExecuteNonQuery();

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }
    }
}
