using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using RestSharpDataDriven.DataTypes;
using System.Collections.Generic;

namespace RestSharpDataDriven.Tests
{
    [TestFixture]
    class DataDrivenTestCaseSourcePetTests
    {
        private const string BASE_URL = "https://petstore.swagger.io/v2";

        [Test, TestCaseSource("LocationTestData")]
        public void FindPetById(long petId)
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/pet/" + petId, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse response = client.Execute(request);

            Assert.That(response.IsSuccessful);
        }

        private static IEnumerable<TestCaseData> LocationTestData()
        {
            yield return new TestCaseData(121991).SetName("Check that petId 121991 is registered");
            yield return new TestCaseData(112316).SetName("Check that petId 121990 is registered");
        }
    }
}
