using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilirarios;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class CatalogoServices : ICatalogo
    {
        private readonly VentasContext _context;
        private ControlError Log = new ControlError();
        public CatalogoServices(VentasContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> GetCategoria()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Categoria.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetCategoria";
                Log.LogErrorMetodos("CatalogoServices", "GerCategoria", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> GetMarca()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Marcas.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetMarca";
                Log.LogErrorMetodos("CatalogoServices", "GetMarca", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> GetModelo()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Modelos.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetModelo";
                Log.LogErrorMetodos("CatalogoServices", "GetModelo", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetSucursal()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Sucursals.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetSucursal";
                Log.LogErrorMetodos("CatalogoServices", "GetSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCategoria(Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var categExistente = await _context.Categoria.FindAsync(categoria.CategId);
                if (categExistente == null)
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe la categoria";
                }
                else
                {
                    categExistente.CategNombre = categoria.CategNombre;
                    categExistente.Estado = categoria.Estado;
                    categExistente.FechaHoraReg = categoria.FechaHoraReg;

                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";

                }

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error";
                Log.LogErrorMetodos("CatalogoServices", "PutCategoria", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PutMarca(Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                var marcaExistente = await _context.Marcas.FindAsync(marca.MarcaId);
                if (marcaExistente == null)
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe la marca";
                }
                else
                {
                    marcaExistente.MarcaNombre = marca.MarcaNombre;
                    marcaExistente.Estado = marca.Estado;
                    marcaExistente.FechaHoraReg = marca.FechaHoraReg;

                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error";
                Log.LogErrorMetodos("CatalogoServices", "PutMarca", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PutModelo(Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                var modeloExistente = await _context.Modelos.FindAsync(modelo.ModeloId);
                if (modeloExistente == null)
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe el modelo";
                }
                else
                {
                    modeloExistente.ModeloDescripción = modelo.ModeloDescripción;
                    modeloExistente.Estado = modelo.Estado;
                    modeloExistente.FechaHoraReg = modelo.FechaHoraReg;

                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }
            return respuesta;
        }
        public async Task<Respuesta> PutSucursal(Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                var sucursalExistente = await _context.Sucursals.FindAsync(sucursal.SucursalId);
                if (sucursalExistente == null)
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe la sucursal";
                }
                else
                {
                    sucursalExistente.SucursalNombre = sucursal.SucursalNombre;
                    sucursalExistente.Estado = sucursal.Estado;
                    sucursalExistente.FechaHoraReg = sucursal.FechaHoraReg;

                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }
            return respuesta;
        }
        public async Task<Respuesta> PostCategoria(Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Categoria.OrderByDescending(x => x.CategId).Select(x => x.CategId).FirstOrDefaultAsync().Result;
                categoria.CategId = Convert.ToInt32(query) + 1;
                categoria.FechaHoraReg = DateTime.Now;

                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";

            }
            return respuesta;
        }
        public async Task<Respuesta> PostMarca(Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Marcas.OrderByDescending(x => x.MarcaId).Select(x => x.MarcaId).FirstOrDefaultAsync().Result;
                marca.MarcaId = Convert.ToInt32(query) + 1;
                marca.FechaHoraReg = DateTime.Now;

                _context.Marcas.Add(marca);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";

            }
            return respuesta;
        }
        public async Task<Respuesta> PostModelo(Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Modelos.OrderByDescending(x => x.ModeloId).Select(x => x.ModeloId).FirstOrDefaultAsync().Result;
                modelo.ModeloId = Convert.ToInt32(query) + 1;
                modelo.FechaHoraReg = DateTime.Now;

                _context.Modelos.Add(modelo);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";

            }
            return respuesta;
        }
        public async Task<Respuesta> PostSucursal(Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Sucursals.OrderByDescending(x => x.SucursalId).Select(x => x.SucursalId).FirstOrDefaultAsync().Result;
                sucursal.SucursalId = Convert.ToInt32(query) + 1;
                sucursal.FechaHoraReg = DateTime.Now;

                _context.Sucursals.Add(sucursal);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";

            }
            return respuesta;
        }
    }
}