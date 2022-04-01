using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetTypeProvider
    {
        HttpClient _client;

        public AssetTypeProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AssetTypeDTO>> GetAssetAsync()
        {
            var request = await _client.GetAsync("assettype");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AssetTypeDTO>>(content);
            }
            else
            {
                return null;
            }

        }

        public async Task<string> AddAsync(AssetTypeDTO assetTypeDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetTypeDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassettype", jsonConversion);
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
