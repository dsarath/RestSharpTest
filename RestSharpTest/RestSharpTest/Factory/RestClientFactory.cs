using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace RestSharpTest.Factory
{
    public class RestClientFactory
    {
        public RestClient Create(string baseUrl)
        {
            return new RestClient(baseUrl);
        }
    }
}
