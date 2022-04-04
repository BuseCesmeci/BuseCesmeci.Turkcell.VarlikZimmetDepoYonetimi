using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class GetAssetTableProvider
    {
        private readonly HttpClient _client;

        public GetAssetTableProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<GetAssetTableDTO>> GetAllAssetTableAsync()
        {
            var request = await _client.GetAsync("getassettable");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GetAssetTableDTO>>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
