using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetPriceProvider
    {
        private readonly HttpClient _client;

        public AssetPriceProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddAssetPriceAsync(PriceDTO priceDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(priceDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetprice", jsonConversion);
                if (responsePostValue.IsSuccessStatusCode)
                {
                    await responsePostValue.Content.ReadAsStringAsync();
                }
                result = "Işlem tamamlandı.";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<PriceDTO> GetAssetPriceAsync()
        {
            var request = await _client.GetAsync("assetprice");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PriceDTO>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UpdateAssetPriceAsync(PriceDTO priceDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(priceDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateassetprice", jsonConversion);
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
