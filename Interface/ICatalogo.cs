using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> GetCategoria();
        Task<Respuesta> GetMarca();
        Task<Respuesta> GetModelo();
        Task<Respuesta> GetSucursal();
        Task<Respuesta> PutCategoria(Categorium categoria);
        Task<Respuesta> PutMarca(Marca marca);
        Task<Respuesta> PutModelo(Modelo modelo);
        Task<Respuesta> PutSucursal(Sucursal sucursal);
        Task<Respuesta> PostCategoria(Categorium categoria);
        Task<Respuesta> PostMarca(Marca marca);
        Task<Respuesta> PostModelo(Modelo modelo);
        Task<Respuesta> PostSucursal(Sucursal sucursal);
    }
}