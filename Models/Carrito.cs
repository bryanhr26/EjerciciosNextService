namespace BlazorApp1.Models
{
    public class Carrito
    {
        public List<Producto> Productos { get; set; } = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }
    }
}
