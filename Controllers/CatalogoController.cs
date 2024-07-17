using EjemploEntity.Interface;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilirarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;
        private ControlError Log = new ControlError();
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCategoria", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutCategoria", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCategoria", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetMarca", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutMarca", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogocController", "PostMarca", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetModelo", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoControllerr", "PutModelo", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostModelo", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetSucursal", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutSucursal", ex.Message);
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostSucursal", ex.Message);
            }
            return respuesta;
        }
    }
}