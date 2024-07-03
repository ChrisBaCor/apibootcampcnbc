using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VentasController : Controller
    {
        private readonly IVentas _venta;
        public VentasController(IVentas venta)
        {
            this._venta = venta;
        }
        [HttpGet]
        [Route("GetVenta")]
        public async Task<Respuesta> GetVenta(string? numFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVenta(numFactura);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}