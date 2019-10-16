using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpTest.Factory
{
    public class RestRequestFactory
    {
        public RestRequest Create(Method method, DataFormat format)
        {
            return new RestRequest(method) { RequestFormat = format };
        }
    }
}
