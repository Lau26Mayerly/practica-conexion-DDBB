using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_conexion_DDBB
{
    public class Ventaslogica
    {

        string connectionString =
        ConfigurationManager
        .ConnectionStrings["CONEXION"]
        .ConnectionString;

        public bool RegistrarVenta(
            int codigoProducto,
            int cliente,
            int vendedor,
            int cantidad)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                SqlTransaction tran =
                conn.BeginTransaction();

                try
                {
                    decimal precio = 0;

                    // Buscar precio producto

                    string sqlBuscar =
                    @"SELECT PRECIO
                      FROM PRODUCTOS
                      WHERE CODIGO=@CODIGO";

                    SqlCommand cmdBuscar =
                    new SqlCommand
                    (sqlBuscar, conn, tran);

                    cmdBuscar.Parameters.AddWithValue
                    ("@CODIGO", codigoProducto);

                    precio =
                    Convert.ToDecimal
                    (cmdBuscar.ExecuteScalar());


                    decimal subtotal =
                    precio * cantidad;

                    decimal iva =
                    subtotal * 0.19m;

                    decimal total =
                    subtotal + iva;



                    // Guardar factura

                    string sqlFactura = @"

                    INSERT INTO FACTURAS
                    (
                      FECHA,
                      SUBTOTAL,
                      IVA,
                      VALOR,
                      DETALLE,
                      CLIENTE,
                      VENDEDOR
                    )

                    VALUES
                    (
                      GETDATE(),
                      @SUBTOTAL,
                      @IVA,
                      @TOTAL,
                      @DETALLE,
                      @CLIENTE,
                      @VENDEDOR
                    )";

                    SqlCommand cmdFactura =
                    new SqlCommand
                    (sqlFactura, conn, tran);

                    cmdFactura.Parameters.AddWithValue
                    ("@SUBTOTAL", subtotal);

                    cmdFactura.Parameters.AddWithValue
                    ("@IVA", iva);

                    cmdFactura.Parameters.AddWithValue
                    ("@TOTAL", total);

                    cmdFactura.Parameters.AddWithValue
                    ("@DETALLE", codigoProducto);

                    cmdFactura.Parameters.AddWithValue
                    ("@CLIENTE", cliente);

                    cmdFactura.Parameters.AddWithValue
                    ("@VENDEDOR", vendedor);

                    cmdFactura.ExecuteNonQuery();



                    // Descontar stock

                    string sqlStock = @"
                    UPDATE PRODUCTOS
                    SET STOCK=STOCK-@CANTIDAD
                    WHERE CODIGO=@CODIGO";

                    SqlCommand cmdStock =
                    new SqlCommand
                    (sqlStock, conn, tran);

                    cmdStock.Parameters.AddWithValue
                    ("@CANTIDAD", cantidad);

                    cmdStock.Parameters.AddWithValue
                    ("@CODIGO", codigoProducto);

                    cmdStock.ExecuteNonQuery();



                    // Registrar rotacion

                    string sqlRotacion = @"

                    INSERT INTO VENTA_ROTACION
                    (
                     ID_PRODUCTO,
                     CANTIDAD,
                     FECHA,
                     ESTADO
                    )

                    VALUES
                    (
                     @CODIGO,
                     @CANTIDAD,
                     GETDATE(),
                     'VENTA'
                    )";

                    SqlCommand cmdRot =
                    new SqlCommand
                    (sqlRotacion, conn, tran);

                    cmdRot.Parameters.AddWithValue
                    ("@CODIGO", codigoProducto);

                    cmdRot.Parameters.AddWithValue
                    ("@CANTIDAD", cantidad);

                    cmdRot.ExecuteNonQuery();


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
