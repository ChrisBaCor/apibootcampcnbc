using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : Controller
    {
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }

        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(int Cliente_Id, string? Cliente_Nombre, double Cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.GetCliente(Cliente_Id, Cliente_Nombre, Cedula);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCliente")]
        public async Task<Respuesta> PutCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PutCliente(cliente);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PostCliente(cliente);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
    }
}
