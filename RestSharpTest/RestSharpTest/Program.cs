using System;
using RestSharp;
using Xunit;
using FluentAssertions;
using RestSharpTest.Models;
using Newtonsoft.Json;
using RestSharpTest.Factory;


namespace RestSharpTest
{
    public class RestSharpTest
    {
        private RestClientFactory restClientFactory = new  RestClientFactory();
        private RestRequestFactory restRequestFactory = new RestRequestFactory();

        private IRestResponse getCEP(object CEP)
        {
            var client = restClientFactory.Create("http://viacep.com.br/ws/" + CEP + "/json/");
            //var client = new RestClient(baseUrl);
            var restRequest = restRequestFactory.Create(Method.GET, DataFormat.Json);
            //var restRequest = new RestRequest(method) { RequestFormat = format };

            return client.Execute(restRequest);
        }

        [Fact]
        public void success()
        {
            var response = getCEP("88034102");
            var json = JsonConvert.DeserializeObject<CorreiosResponse>(response.Content);

            response.StatusCode.Should().Be(200);
            json.Bairro.Should().Be("Itacorubi");
            json.Logradouro.Should().Be("Rodovia Amaro Antônio Vieira");
        }

    }
}
