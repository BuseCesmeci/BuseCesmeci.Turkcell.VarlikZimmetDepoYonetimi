using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetOwnerProvider
    {
        private readonly HttpClient _client;

        public AssetOwnerProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddAssetOwnerAsync(AssetOwnerDTO ownerDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(ownerDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetowner", jsonConversion);
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

        public async Task<List<AssetOwnerDTO>> GetAssetOwnerAsync()
        {
            var request = await _client.GetAsync("assetowner");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AssetOwnerDTO>>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> AddAssetOwnerAsync(DebitDTO debitDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(debitDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetowner", jsonConversion);
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
    }
}
