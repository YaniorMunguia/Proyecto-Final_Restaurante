namespace Modelos
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public string CodigoProducto_Bebida { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public DetalleFactura()
        {
        }

        public DetalleFactura(int id, int idFactura, string codigoProducto_Bebida, string descripcion, decimal precio, int cantidad, decimal total)
        {
            Id=id;
            IdFactura=idFactura;
            CodigoProducto_Bebida=codigoProducto_Bebida;
            Descripcion=descripcion;
            Precio=precio;
            Cantidad=cantidad;
            Total=total;
        }
    }

}
