using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetActionOptionsProvider
    {
        private readonly HttpClient _client;

        public AssetActionOptionsProvider(HttpClient client)
        {
            _client = client;
        }
        public async Task<AssetActionOptionsDTO> GetActionOptionAsync()
        {
            var request = await _client.GetAsync("assetaction");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetActionOptionsDTO>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
