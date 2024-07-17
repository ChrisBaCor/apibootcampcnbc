using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilirarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EjemploEntity.Services
{
    public class VendedorServices : IVendedor
    {
        private readonly VentasContext _context;
        ControlError Log = new ControlError();
        public VendedorServices(VentasContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> GetVendedor(double? id, string? estado)
        {
            var respuesta = new Respuesta();
            try
            {
                IQueryable<Vendedor> query = _context.Vendedors;

                if (id == null && estado == null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.ToListAsync();
                    respuesta.Mensaje = "OK";

                }
                else if (id is not null && estado is not null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from q in query
                                            where q.Estado == estado && q.VendedorId == id
                                            select q).ToListAsync();
                    respuesta.Mensaje = "OK";

                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "Datos no existente";
                }
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VendedorServices", "GetVendedor", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PostVendedor(Vendedor vendedor)
        {
            var respuesta = new Respuesta();

            try
            {
                bool existsId = await _context.Vendedors.AnyAsync(x => x.VendedorId == vendedor.VendedorId);
                char initialCode = 'V';
                char dash = '-';

                if (!existsId)
                {
                    int? maxID = await _context.Vendedors.OrderByDescending(x => x.VendedorId).Select(x => x.VendedorId).FirstOrDefaultAsync(); 
                    int newID = (maxID.HasValue ? maxID.Value : 0) + 1; 
                    string strID = newID.ToString(); 

                    vendedor.VendedorId = newID;
                    vendedor.VendedorDescripcion = initialCode + strID + dash + vendedor.VendedorDescripcion;

                    await _context.Vendedors.AddAsync(vendedor);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = vendedor;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "ID vendedor ya se encuentra registrado";
                }

            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VendedorServices", ex.Message, "PostVendedor");
            }
            return respuesta;

        }
        public async Task<Respuesta> PutVendedor(Vendedor vendedor)
        {
            var respuesta = new Respuesta();

            try
            {
                bool existID = await _context.Vendedors.AnyAsync(x => x.VendedorId == vendedor.VendedorId);

                if (existID && vendedor.VendedorDescripcion is not null)
                {
                    vendedor.VendedorDescripcion = 'V' + vendedor.VendedorId.ToString() + '-' + vendedor.VendedorDescripcion;

                    _context.Vendedors.Update(vendedor);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = vendedor;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe un vendedor registrado con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VendedorServices", ex.Message, "PutVendedor");
            }
            return respuesta;
        }
        public async Task<Respuesta> DeleteVendedor(double id)
        {
            var respuesta = new Respuesta();
            try
            {
                Vendedor? vendedorToDelete = await _context.Vendedors.FirstOrDefaultAsync(x => x.VendedorId == id);

                if (vendedorToDelete is not null)
                {
                    vendedorToDelete.Estado = "I";

                    _context.Vendedors.Update(vendedorToDelete);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = vendedorToDelete;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe un vendedor registrado con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VendedorServices", ex.Message, "DeleteVendedor");
            }
            return respuesta;
        }
    }
}
