using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class PersonnelProvider
    {
        private readonly HttpClient _client;

        public PersonnelProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddAsync(PersonnelDTO personelDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(personelDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addpersonnel", jsonConversion);
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

        public async Task<List<PersonnelDTO>> GetAsync()
        {
            var request = await _client.GetAsync("personnel");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PersonnelDTO>>(content);
            }
            else
            {
                return null;
            }

        }
    }
}
