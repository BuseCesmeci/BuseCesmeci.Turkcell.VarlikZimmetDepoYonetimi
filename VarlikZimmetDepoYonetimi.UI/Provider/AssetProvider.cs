using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;
using VarlikZimmetDepoYonetimi.UI.Models.VM;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetProvider
    {
        private readonly HttpClient _client;

        public AssetProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddAsync(AssetDTO assetDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addasset", jsonConversion);
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
        public async Task<string> AddVMAsync(AssetDTO alvm)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(alvm));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addasset", jsonConversion);
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

        public async Task<string> TokenAddAsync(AssetDTO assetDto, string token = null)
        {
            if (token == null)
            {
                return "token yok";
            }

            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var responsePostValue = await _client.PostAsync("addasset", jsonConversion);
            string result = "";
            if (responsePostValue.IsSuccessStatusCode)
            {
                result = "Işlem tamamlandı.";
            }

            return result;
        }

        public async Task<string> UpdateAsync(AssetDTO assetDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateasset", jsonConversion);
                if (responseValue.IsSuccessStatusCode)
                {
                    result = "Işlem tamamlandı.";
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<string> DeleteAsync(int assetID)
        {
            var request = await _client.DeleteAsync("asset/" + assetID);

            string result = "";
            if (request.IsSuccessStatusCode)
            {
                result = "Işlem tamamlandı.";
            }
            return result;
        }

        public async Task<List<AssetDTO>> GetAssetAsync()
        {
            var request = await _client.GetAsync("asset");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AssetDTO>>(content);
            }
            else
            {
                return null;
            }
           
        }
        public async Task<DropDownLoadDTO> GetAssetDetailAsync()
        {
            var request = await _client.GetAsync("assetdetail");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DropDownLoadDTO>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<AssetDTO> GetAssetByIDAsync(int assetID)
        {
            var request = await _client.GetAsync("asset/" + assetID);

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetDTO>(content);
            }
            else
            {
                return null;
            }
            
        }


        // BARCODE

        public async Task<string> AddBorcodeAsync(AssetBarcodeDTO assetBarcodeDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetBarcodeDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetbarcode", jsonConversion);
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

        public async Task<AssetBarcodeDTO> GetBarcodeAsync()
        {
            var request = await _client.GetAsync("asset");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetBarcodeDTO>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UpdateBarcodeAsync(AssetBarcodeDTO assetBarcodeDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetBarcodeDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateassetbarcode", jsonConversion);
                if (responseValue.IsSuccessStatusCode)
                {
                    result = "Işlem tamamlandı.";
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        // ASSET STATUS

        public async Task<string> AddAssetStatusAsync(AssetStatusDTO assetStatusDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetStatusDto));
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

        public async Task<AssetStatusDTO> GetAssetStatusAsync()
        {
            var request = await _client.GetAsync("asset");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetStatusDTO>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UpdateAssetStatusAsync(AssetStatusDTO assetStatusDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetStatusDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateassetstatus", jsonConversion);
                if (responseValue.IsSuccessStatusCode)
                {
                    result = "Işlem tamamlandı.";
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        //  PRICE

        public async Task<string> AddAssetPriceAsync(PriceDTO priceDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(priceDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetprice", jsonConversion);
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

        public async Task<PriceDTO> GetAssetPriceAsync()
        {
            var request = await _client.GetAsync("asset");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PriceDTO>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UpdateAssetPriceAsync(PriceDTO priceDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(priceDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateassetprice", jsonConversion);
                if (responseValue.IsSuccessStatusCode)
                {
                    result = "Işlem tamamlandı.";
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        // UNIT 

        public async Task<string> AddAssetUnitAsync(UnitDTO unitDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(unitDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responsePostValue = await _client.PostAsync("addassetunit", jsonConversion);
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

        public async Task<UnitDTO> GetAssetUnitAsync()
        {
            var request = await _client.GetAsync("asset");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UnitDTO>(content);
            }
            else
            {
                return null;
            }
        }

        // ASSETTYPE

        public async Task<List<AssetTypeDTO>> GetAssetTypeAsync()
        {
            var request = await _client.GetAsync("asset");

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

        public async Task<string> UpdateAssetTypeAsync(AssetTypeDTO assetTypeDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(assetTypeDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updateassettype", jsonConversion);
                if (responseValue.IsSuccessStatusCode)
                {
                    result = "Işlem tamamlandı.";
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        // ASSET GROUP

        public async Task<List<AssetGroupDTO>> GetAssetGroupAsync()
        {
            var request = await _client.GetAsync("asset");

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

        // BRAND MODEL  

        public async Task<List<BrandModelDTO>> GetAssetBrandModelAsync()
        {
            var request = await _client.GetAsync("asset");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BrandModelDTO>>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UpdateBrandModelAsync(BrandModelDTO brandModelDto)
        {
            var jsonConversion = new StringContent(JsonConvert.SerializeObject(brandModelDto));
            jsonConversion.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string result = "";
            try
            {
                var responseValue = await _client.PutAsync("updatebrandmodel", jsonConversion);
                if (responseValue.IsSuccessStatusCode)
                {
                    result = "Işlem tamamlandı.";
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
