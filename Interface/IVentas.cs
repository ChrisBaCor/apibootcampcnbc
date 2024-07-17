using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetVenta(string? numFactura, double precio, double vendedor, double clienteId, string fechaDesde, string fechaHasta);
        Task<Respuesta> PostVenta(Venta venta);
        Task<Respuesta> PutVenta(Venta venta);
        Task<Respuesta> GetVentaReporte();
    }
}
