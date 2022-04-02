using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class BrandModelProvider
    {
        private readonly HttpClient _client;

        public BrandModelProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<BrandModelDTO>> GetAssetBrandModelAsync()
        {
            var request = await _client.GetAsync("brandmodel");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BrandModelDTO>>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UpdateBrandModelAsync(BrandModelDTO brandModelDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(brandModelDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updatebrandmodel", jsonConversion);
                if (responseValue.IsSuccessStatusCode)
                {
                    result = "Işlem tamamlandı.";
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
