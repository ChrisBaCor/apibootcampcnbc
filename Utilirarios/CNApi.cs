using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EjemploEntity.Utilirarios
{
    public class CNApi
    {
        private ControlError Log = new ControlError();
        public async Task<Respuesta> GetCNApi(string url)
        {
            var respuesta = new Respuesta();

            try
            {

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.chucknorris.io/jokes/random");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<CNApiDto>(json); //construye el json como un objeto
                respuesta.Mensaje = "Se consumio correctamente";

                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CNApi", "GetCNApi", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetCNApiRandomCategory(string url, string categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?category={categoria}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<CNApiRandomCategory>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";


            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CNApi", "GetCNApiRandomCategory", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetCNApiCategory(string url)
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
                respuesta.Data = JsonConvert.DeserializeObject<CNApiQueryDTO>(json);
                respuesta.Data = JsonConvert.DeserializeObject<List<string>>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CNApi", "GetCNApiCategory", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetCNApiQuery(string url, string texto)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?query={texto}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                
                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<CNApiQueryDTO>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";


            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CNApi", "GetCNApiQuery", ex.Message);
            }
            return respuesta;
        }

    }
}