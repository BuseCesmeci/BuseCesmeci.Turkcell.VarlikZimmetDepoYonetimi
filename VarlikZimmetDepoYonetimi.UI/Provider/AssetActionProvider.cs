using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class AssetActionProvider
    {
       HttpClient _client;

        public AssetActionProvider(HttpClient client)
        {
            _client = client;
        }


    }
}
