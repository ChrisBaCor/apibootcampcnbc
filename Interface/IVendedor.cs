using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface IVendedor
    {
        Task<Respuesta> GetVendedor(double? id, string? estado);
        Task<Respuesta> PostVendedor(Vendedor vendedor);
        Task<Respuesta> PutVendedor(Vendedor vendedor);
        Task<Respuesta> DeleteVendedor(double id);
    }
}

