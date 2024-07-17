using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilirarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VentasController : Controller
    {
        private readonly IVentas _venta;
        private ControlError Log = new ControlError();
        public VentasController(IVentas venta)
        {
            this._venta = venta;
        }
        [HttpGet]
        [Route("GetVenta")]
        public async Task<Respuesta> GetVenta(string? numFactura, double precio, double vendedor, double clienteId, string fechaDesde, string fechaHasta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVenta(numFactura, precio, vendedor, clienteId, fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentasController", "GetVentas", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("PostVenta")]
        public async Task<Respuesta>PostVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PostVenta(venta);

            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentasController", "PostVenta", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("PutVenta")]
        public async Task<Respuesta> PutVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PutVenta(venta);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentasController", "PutVenta", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetVentaReporte")]
        public async Task<Respuesta> GetVentaReporte()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVentaReporte();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentasController", "GetVentaReporte", ex.Message);
            }
            return respuesta;
        }

    }
}