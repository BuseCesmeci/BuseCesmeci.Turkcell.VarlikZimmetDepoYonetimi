using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetBarcodeProvider
    {
        private readonly HttpClient _client;

        public AssetBarcodeProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddBorcodeAsync(AssetBarcodeDTO assetBarcodeDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetBarcodeDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetbarcode", jsonConversion);
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

        public async Task<AssetBarcodeDTO> GetBarcodeAsync()
        {
            var request = await _client.GetAsync("assetbarcode");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetBarcodeDTO>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UpdateBarcodeAsync(AssetBarcodeDTO assetBarcodeDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetBarcodeDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateassetbarcode", jsonConversion);
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
