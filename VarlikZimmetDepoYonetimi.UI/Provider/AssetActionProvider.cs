using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetActionProvider
    {
        private readonly HttpClient _client;

        public AssetActionProvider(HttpClient client)
        {
            _client = client;
        }
        
        public async Task<DebitReasonLoadDTO> GetDebitReasonAsync()
        {
            var request = await _client.GetAsync("assetactionoptions");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DebitReasonLoadDTO>(content);
            }
            else
            {
                return null;
            }
        }



        public async Task<DebitRetiredLoadDTO> GetDebitRetiredAsync()
        {
            var request = await _client.GetAsync("retiredaction");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DebitRetiredLoadDTO>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
