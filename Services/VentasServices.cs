using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilirarios;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EjemploEntity.Services
{
    public class VentasServices : IVentas

    {
        private readonly VentasContext _context;
        private ControlError Log = new ControlError();
        public VentasServices(VentasContext context)
        {
            this._context = context;
        }


        public async Task<Respuesta> GetVenta(string? numFactura)
        { 
            var respuesta = new Respuesta();
            try
            {
                if (numFactura != null && !numFactura.Equals("0"))
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join vv in _context.Vendedors on v.VendedorId equals vv.VendedorId
                                            join cc in _context.Cajas on v.CajaId equals cc.CajaId
                                            where v.NumFact.Equals(numFactura)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = cc.CajaDescripcion,
                                                Vendedor = vv.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado,
                                            }).ToListAsync();

                    respuesta.Mensaje = "Ok";
                }
                else
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join cc in _context.Cajas on v.CajaId equals cc.CajaId
                                            join vv in _context.Vendedors on v.VendedorId equals vv.VendedorId
                                            where v.Estado == 2
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = cc.CajaDescripcion,
                                                Vendedor = vv.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();

                    respuesta.Mensaje = "Ok";
                    Log.LogErrorMetodos("VentasServices", "GetVenta", "PruebaLog");
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento una novedad, contactarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentasServices", "GetVenta", ex.Message);
            }
            return respuesta;
        }

        public Task<Respuesta> GetVenta(string? numFactura, double precio, double vendedor, double clienteId, string fechaDesde, string fechaHasta)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> GetVentaReporte()
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> PostVenta(Venta venta)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> PutVenta(Venta venta)
        {
            throw new NotImplementedException();
        }
    }
}
