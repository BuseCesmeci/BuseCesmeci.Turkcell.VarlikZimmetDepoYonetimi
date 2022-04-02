using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetStatusProvider
    {
        private readonly HttpClient _client;

        public AssetStatusProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddAssetStatusAsync(AssetStatusDTO assetStatusDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetStatusDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetstatus", jsonConversion);
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

        public async Task<AssetStatusDTO> GetAssetStatusAsync()
        {
            var request = await _client.GetAsync("assetstatus");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetStatusDTO>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UpdateAssetStatusAsync(AssetStatusDTO assetStatusDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetStatusDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateassetstatus", jsonConversion);
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
