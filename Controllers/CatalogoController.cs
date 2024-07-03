using EjemploEntity.Interface;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;
        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }
        [HttpGet]
        [Route("GetCategoria")]
        public async Task<Respuesta> GetCategoria()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCategoria();
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetMarca")]
        public async Task<Respuesta> GetMarca()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetMarca();
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetModelo")]
        public async Task<Respuesta> GetModelo()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetModelo();
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetSucursal")]
        public async Task<Respuesta> GetSucursal()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetSucursal();
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCategoria")]
        public async Task<Respuesta> PutCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCategoria(categoria);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutMarca")]
        public async Task<Respuesta> PutMarca([FromBody] Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutMarca(marca);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutModelo")]
        public async Task<Respuesta> PutModelo([FromBody] Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutModelo(modelo);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutSucursal")]
        public async Task<Respuesta> PutSucursal([FromBody] Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutSucursal(sucursal);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostCategoria")]
        public async Task<Respuesta> PostCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCategoria(categoria);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostMarca")]
        public async Task<Respuesta> PostMarca([FromBody] Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostMarca(marca);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostModelo")]
        public async Task<Respuesta> PostModelo([FromBody] Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostModelo(modelo);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostSucursal")]
        public async Task<Respuesta> PostSucursal([FromBody] Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostSucursal(sucursal);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
    }
}