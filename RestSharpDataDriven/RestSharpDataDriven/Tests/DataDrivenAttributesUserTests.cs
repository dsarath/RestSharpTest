using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using RestSharpDataDriven.DataTypes;

namespace RestSharpDataDriven.Tests
{
    [TestFixture]
    class DataDrivenAttributesUserTests
    {
        private const string BASE_URL = "https://petstore.swagger.io/v2";

        [TestCase("restsharp", TestName = "Check the user restsharp")]
        public void FindUser(string userName)
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/user/" + userName, Method.GET) { RequestFormat = DataFormat.Json };
            
            IRestResponse response = client.Execute(request);

            Assert.That(response.IsSuccessful);
        }

        [TestCase("A", TestName = "Check A user")]
        [TestCase("rest", TestName = "Check an inexistent user")]
        public void FindWrongUser(string userName)
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/user/" + userName, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse response = client.Execute(request);
            var FindUserResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

            Assert.That(FindUserResponse.type, Is.EqualTo("error"));
            Assert.That(FindUserResponse.message, Is.EqualTo("User not found"));
        }
    }
}
