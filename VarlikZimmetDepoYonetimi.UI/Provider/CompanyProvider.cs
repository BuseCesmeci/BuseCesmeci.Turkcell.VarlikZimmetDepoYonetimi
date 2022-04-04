using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class CompanyProvider
    {
        private readonly HttpClient _client;

        public CompanyProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<CompanyDTO> GetCompanyAsync()
        {
            var request = await _client.GetAsync("company");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CompanyDTO>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
