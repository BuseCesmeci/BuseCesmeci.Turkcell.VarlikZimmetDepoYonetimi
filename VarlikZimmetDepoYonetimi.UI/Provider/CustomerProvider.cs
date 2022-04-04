using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class CustomerProvider
    {
        private readonly HttpClient _client;

        public CustomerProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddAsync(CustomerDTO customerDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(customerDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addcustomer", jsonConversion);
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
        public async Task<string> AddToConsumeAsync(AssetToReturnDTO consumeDTO)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(consumeDTO));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addcustomer", jsonConversion);
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

        public async Task<CustomerDTO> GetAsync()
        {
            var request = await _client.GetAsync("customer");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CustomerDTO>(content);
            }
            else
            {
                return null;
            }

        }
    }
}
