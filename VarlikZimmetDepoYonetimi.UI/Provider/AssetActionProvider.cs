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
       HttpClient _client;

        public AssetActionProvider(HttpClient client)
        {
            _client = client;
        }

        // ASSET STATUS

        public async Task<string> AddAssetStatusAsync(AssetStatusDTO assetStatusdto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetStatusdto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetstatus", jsonConversion);
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

        // ZIMMET ATA

        public async Task<string> AddAssetOwnerAsync(AssetOwnerDTO assetOwnerDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetOwnerDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetowner", jsonConversion);
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


        public async Task<AssetOwnerDTO> GetAssetDetailAsync()
        {
            var request = await _client.GetAsync("asset");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetOwnerDTO>(content);
            }
            else
            {
                return null;
            }
        }

        // DEPOYA ATA

        public async Task<CompanyDTO> GetCompanyAsync()
        {
            var request = await _client.GetAsync("asset");

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

        // TÜKET

        public async Task<string> AddAssetCustomerAsync(AssetCustomerDTO assetcustomerDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetcustomerDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetcustomer", jsonConversion);
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

        public async Task<CustomerDTO> GetCustomerAsync()
        {
            var request = await _client.GetAsync("asset");

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

        //  YORUM EKLE

        public async Task<string> AddCommentAsync(CommentDTO commentDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(commentDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addcomment", jsonConversion);
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
