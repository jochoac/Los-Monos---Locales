namespace Logica
{
    public class Consolidado
    {
        private string cod_entrega, cod_producto, nom_producto, fecha, hora, local, marca, verificado;
        private long cantidad, precio, subtotal;

        public long Cantidad { get => cantidad; set => cantidad = value; }
        public string Cod_entrega { get => cod_entrega; set => cod_entrega = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public string Nom_producto { get => nom_producto; set => nom_producto = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public string Local { get => local; set => local = value; }
        public string Marca { get => marca; set => marca = value; }
        public long Precio { get => precio; set => precio = value; }
        public long Subtotal { get => subtotal; set => subtotal = value; }
        public string Verificado { get => verificado; set => verificado = value; }
    }
}