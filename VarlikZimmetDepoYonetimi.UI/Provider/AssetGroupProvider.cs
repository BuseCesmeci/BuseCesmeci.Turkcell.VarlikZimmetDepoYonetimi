using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetGroupProvider
    {
        private readonly HttpClient _client;

        public AssetGroupProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AssetGroupDTO>> GetAssetGroupAsync()
        {
            var request = await _client.GetAsync("assetgroup");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AssetGroupDTO>>(content);
            }
            else
            {
                return null;
            }

        }
    }
}
