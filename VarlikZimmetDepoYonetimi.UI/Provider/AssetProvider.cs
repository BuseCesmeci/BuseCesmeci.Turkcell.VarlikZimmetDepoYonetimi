using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetProvider
    {
        private readonly HttpClient _client;

        public AssetProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddAsync(AssetDTO assetDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addasset", jsonConversion);
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

        public async Task<string> TokenAddAsync(AssetDTO assetDto, string token = null)
        {
            if (token == null)
            {
                return "token yok";
            }

            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var responsePostValue = await _client.PostAsync("addasset", jsonConversion);
            string result = "";
            if (responsePostValue.IsSuccessStatusCode)
            {
                result = "Işlem tamamlandı.";
            }

            return result;
        }

        public async Task<string> UpdateAsync(AssetDTO assetDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateproducts", jsonConversion);
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

        public async Task<string> DeleteAsync(int assetID)
        {
            var request = await _client.DeleteAsync("asset/" + assetID);

            string result = "";
            if (request.IsSuccessStatusCode)
            {
                result = "Işlem tamamlandı.";
            }
            return result;
        }

        public async Task<List<AssetDTO>> GetAssetAsync()
        {
            var request = await _client.GetAsync("asset");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AssetDTO>>(content);
            }
            return null;
        }

        public async Task<AssetDTO> GetAssetByIDAsync(int assetID)
        {
            var request = await _client.GetAsync("asset/" + assetID);

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetDTO>(content);
            }
            return null;
        }
    }
}
