using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class OwnerTypeProvider
    {
        HttpClient _client;

        public OwnerTypeProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<OwnerTypeDTO>> GetOwnerTypeAsync()
        {
            var request = await _client.GetAsync("ownertype");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<OwnerTypeDTO>>(content);
            }
            else
            {
                return null;
            }

        }
    }
}
