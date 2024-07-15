using EjemploEntity.Interface;
using EjemploEntity.Utilirarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Models
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        //crear relación de dependencia

        private readonly IProducto _producto;
        private ControlError Log = new ControlError();

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
            catch (Exception ex)
            {

                Log.LogErrorMetodos("ProductoController", "GetListaProducto", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "GetProdPrecio", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PostProducto", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PutProducto", ex.Message);
            }
            return respuesta;
        }
    }
}
