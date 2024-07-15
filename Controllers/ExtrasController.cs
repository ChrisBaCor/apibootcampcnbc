using EjemploEntity.Models;
using EjemploEntity.Utilirarios;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExtrasController : Controller
    {
        private ControlError Log = new ControlError();

        //crear constructor que nos permita tomar el apisetting
        private readonly IConfiguration _configuration;

        private PokeApi pokeApi = new PokeApi();

        private CNApi cnApi = new CNApi();

        public ExtrasController(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        [HttpGet]
        [Route("GetPokeApi")]
        public async Task<Respuesta> GetPokeApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlPoleApi").Value!;

                respuesta = await pokeApi.GetPokeApi(url);
                
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("ExtrasController", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCNApi")]
        public async Task<Respuesta> GetCNApi(String? Url)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlCNApi").Value;
                respuesta = await cnApi.GetCNApi(url);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("ExtrasController", "GetCNApi", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCNApiRandomCategory")]
        public async Task<Respuesta> GetCNApiRandomCategory(string categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlCNApiCategoryRandom").Value!;
                respuesta = await cnApi.GetCNApiRandomCategory(url, categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetCNApiRandomCategory", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCNApiCategory")]
        public async Task<Respuesta> GetCNApiCategory()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlCNApiCategory").Value!;
                respuesta = await cnApi.GetCNApiCategory(url);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetCNApiCategory", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCNApiQuery")]
        public async Task<Respuesta> GetCNApiQuery(string texto)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlCNApiQuery").Value!;
                respuesta = await cnApi.GetCNApiQuery(url, texto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetCNApiQuery", ex.Message);
            }
            return respuesta;
        }


    }
}
