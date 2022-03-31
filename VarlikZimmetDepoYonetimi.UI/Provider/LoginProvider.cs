using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Provider
{
    public class LoginProvider
    {
        HttpClient _client;

        public LoginProvider(HttpClient client)
        {
            _client = client;
        }
    }
}
