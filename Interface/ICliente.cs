using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> GetCliente(int Cliente_Id, string? Cliente_Nombre, double Cedula);
        Task<Respuesta> PutCliente(Cliente cliente);
        Task<Respuesta> PostCliente(Cliente cliente);
    }
}
