using EjemploEntity.Models;

namespace EjemploEntity.Interface
{
    public interface IProducto
    {
        Task<List<Producto>> GetListaProducto(int productoID);

        Task<List<Producto>> GetProdPrecio(double precio);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
    }
}
