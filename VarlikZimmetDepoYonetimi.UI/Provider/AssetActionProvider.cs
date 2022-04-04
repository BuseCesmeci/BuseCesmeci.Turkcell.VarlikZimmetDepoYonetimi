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
    
    }
}
