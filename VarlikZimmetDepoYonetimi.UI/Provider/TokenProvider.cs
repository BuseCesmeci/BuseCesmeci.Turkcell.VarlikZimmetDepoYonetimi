using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class TokenProvider
    {
        HttpClient _client;
        public TokenProvider(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> TokenAl(string kullaniciAdi, string sifre)
        {
            StringContent mycontent = new StringContent(JsonConvert.SerializeObject(new LoginDTO()
            {
                Password = sifre,
                Username = kullaniciAdi
            }));
            mycontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var value = await _client.PostAsync("auth/login", mycontent);
            string token = "";
            if (value.IsSuccessStatusCode)
            {
                token = value.Content.ReadAsStringAsync().Result;
            }
            else
            {
                token = "";
            }
            return token;
        }
    }
}
