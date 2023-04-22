using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MV2AudioRecorder.Models;
using Newtonsoft.Json;

namespace MV2AudioRecorder.Api
{
    
    public class ApiNotas
    {
        private static readonly string URL_SITIOS = "https://movil2grupo5.000webhostapp.com/Apiexa/";

        private static HttpClient client = new HttpClient();

        public async static Task<bool> CreateUsuario(AudioModel nota)
        {
            try
            {
                Uri requestUri = new Uri(URL_SITIOS + "notas.php");
                var jsonObject = JsonConvert.SerializeObject(nota);
                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUri, content);

                Console.WriteLine(response.ToString());

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }


    }
}
