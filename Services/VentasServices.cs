using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EjemploEntity.Services
{
    public class VentasServices : IVentas
    {
        private readonly VentasContext _context;
        public VentasServices(VentasContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> GetVenta(string? numFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                if (numFactura != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join cc in _context.Vendedors on v.VendedorId equals cc.VendedorId
                                            join vv in _context.Cajas on v.CajaId equals vv.CajaId
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
                                                Caja = v.CajaId,
                                                Vendedor = v.VendedorId,
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
                                            where v.Estado.Equals("Registrada")
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
                                                Caja = v.CajaId,
                                                Vendedor = v.VendedorId,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();

                    respuesta.Mensaje = "Ok";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
