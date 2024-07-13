using EjemploEntity.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Models
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        //crear relación de dependencia

        private readonly IProducto _producto;

        public ProductoController(IProducto producto)
        {
            this._producto = producto;
        }

        //crear el método de consulta
        [HttpGet]
        [Route("GetListaProductos")]
        public async Task<List<Producto>> GetListaProducto(int productoID) // agg using EjemploEnttity.Models;
        {
            var respuesta = new List<Producto>();
            try
            {
                respuesta = await _producto.GetListaProducto(productoID);

            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }

        [HttpGet]
        [Route("GetProdPrecio")]
        public async Task<List<Producto>> GetProdPrecio(double precio)
        {
            var respuesta = new List<Producto>();
            try
            {
                respuesta = await _producto.GetProdPrecio(precio);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostProducto(producto);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
    }
}
