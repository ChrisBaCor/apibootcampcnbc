using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class ClienteServices : ICliente
    {
        private readonly VentasContext _context;
        public ClienteServices(VentasContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetCliente(int Cliente_Id, string? Cliente_Nombre, double Cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes;

                if (Cliente_Id == 0 && Cliente_Nombre == null && Cedula == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado == "A").ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (Cliente_Id != 0 && Cliente_Nombre == null && Cedula == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado == "A" && x.ClienteId.Equals(Cliente_Id)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (Cliente_Id == 0 && Cliente_Nombre != null && Cedula == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado == "A" && x.ClienteNombre.Equals(Cliente_Nombre)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (Cliente_Id == 0 && Cliente_Nombre == null && Cedula != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado == "A" && x.Cedula.Equals(Cedula)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (Cliente_Id != 0 && Cliente_Nombre != null && Cedula != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado == "A" && x.ClienteId.Equals(Cliente_Id) && x.ClienteNombre.Equals(Cliente_Nombre) && x.Cedula.Equals(Cedula)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se ha presentado una novedad en el Metodo: GetCliente, Error: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                var clienteExistente = await _context.Clientes.FindAsync(cliente.ClienteId);
                if (clienteExistente == null)
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe el cliente";
                }
                else
                {
                    clienteExistente.ClienteNombre = cliente.ClienteNombre;
                    clienteExistente.Cedula = cliente.Cedula;
                    clienteExistente.Estado = cliente.Estado;
                    clienteExistente.FechaHoraReg = cliente.FechaHoraReg;

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

        public async Task<Respuesta> PostCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes.OrderByDescending(x => x.ClienteId).Select(x => x.ClienteId).FirstOrDefaultAsync().Result;
                cliente.ClienteId = Convert.ToInt32(query) + 1;
                cliente.FechaHoraReg = DateTime.Now;

                _context.Clientes.Add(cliente);
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
