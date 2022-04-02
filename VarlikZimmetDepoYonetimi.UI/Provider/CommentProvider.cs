using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class CommentProvider
    {
        private readonly HttpClient _client;

        public CommentProvider(HttpClient client)
        {
            _client = client;
        }

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
            }
            return result;
        }
    }
}
