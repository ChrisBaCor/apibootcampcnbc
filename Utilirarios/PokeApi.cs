using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilirarios
{
    public class PokeApi
    {
        private ControlError Log = new ControlError();
        public async Task<Respuesta> GetPokeApi(string url)
        {
            var respuesta = new Respuesta();

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<PokeApiDTO>(json); //construye el json como un objeto
                respuesta.Mensaje = "Se consumio correctamente";
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PokeApi", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }
          
    }
}
