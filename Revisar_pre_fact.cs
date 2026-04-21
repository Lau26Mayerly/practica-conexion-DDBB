using System;

public class Revisar_pre_fact
{
	public Revisar_pre_fact()
	{
		public class Productos
	{
		public string ID_producto { get; set; }
		public string Nombre_producto { get; set; }
		public int Cantidad { get; set; }
		public decimal ValorUnit { get; set; }

		public decimal Total = Cantidad * ValorUnit;
	}
}
