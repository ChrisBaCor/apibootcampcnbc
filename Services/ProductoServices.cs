using EjemploEntity.Interface;
using EjemploEntity.Models;
using EjemploEntity.Utilirarios;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class ProductoServices : IProducto
    {
        private readonly VentasContext _context;
        private ControlError Log = new ControlError();

        public ProductoServices(VentasContext context)
        {
            this._context = context;
        }

        public async Task<List<Producto>> GetListaProducto(int productoID)
        {
            var respuesta = new List<Producto>();
            try
            {
                if (productoID == 0)
                {
                    respuesta = await _context.Productos.ToListAsync();
                }
                else
                {
                    respuesta = await _context.Productos.Where(x => x.ProductoId.Equals(productoID)).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoServices", "GetListaProducto", ex.Message);
            }

            return respuesta;
        }

        public async Task<List<Producto>> GetProdPrecio(double precio)
        {
            var respuesta = new List<Producto>();
            try
            {
                if (precio == 0)
                {
                    respuesta = await _context.Productos.ToListAsync();
                }
                else
                {
                    respuesta = await _context.Productos.Where(x => x.Precio == precio).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("ProductoServices", "GetListaPrecio", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Productos.OrderByDescending(x => x.ProductoId).Select(x => x.ProductoId).FirstOrDefaultAsync().Result;
                producto.ProductoId = Convert.ToInt32(query) + 1;
                producto.FechaHoraReg = DateTime.Now;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ProductoServices", "PostProducto", ex.Message);

            }
            return respuesta;
        }
        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            bool valida = false;
            try
            {
                valida = await _context.Categoria.Where(x => x.CategId.Equals(producto.CategId)).AnyAsync();
                if (valida)
                {
                    _context.Productos.Update(producto);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizo correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = $"No existe categoria";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ProductoServices", "PutProducto", ex.Message);
            }
            return respuesta;
        }
    }
}