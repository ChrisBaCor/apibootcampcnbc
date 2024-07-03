using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetVenta(string? numFactura);
    }
}
