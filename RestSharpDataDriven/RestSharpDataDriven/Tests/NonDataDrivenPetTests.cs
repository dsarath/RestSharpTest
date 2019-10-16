using NUnit.Framework;
using RestSharp;
using RestSharpDataDriven.DataTypes;
using Newtonsoft.Json;

namespace RestSharpDataDriven.Tests
{
    [TestFixture]
    class NonDataDrivenPetTests
    {
        private const string BASE_URL = "https://petstore.swagger.io/v2";

        [Test]
        public void NewPetRegister()
        {
            string jpet = "{ \"id\": 121991, \"category\": { \"id\": 0, \"name\": \"string\" }, \"name\": \"blackCat\", \"photoUrls\": [ \"string\" ], \"tags\": [ { \"id\": 0, \"name\": \"string\" } ], \"status\": \"available\"}";
            //MockPet mock = new MockPet(new Pet());
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/pet", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(jpet);

            IRestResponse response = client.Execute(request);
            var newPetRegisterResponse = JsonConvert.DeserializeObject<Pet>(response.Content);

            if (response.IsSuccessful)//assert
                Assert.That(newPetRegisterResponse.petName, Is.EqualTo("blackCat"));
            else
                Assert.Fail();
        }

        [Test]
        public void FindPetById()
        {
            long petId = 121991;
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/pet/" + petId, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse response = client.Execute(request);
            var FindPetResponse = JsonConvert.DeserializeObject<Pet>(response.Content);

            if (response.IsSuccessful)//assert
            {
                Assert.That(FindPetResponse.petName, Is.EqualTo("blackCat"));
                Assert.That(FindPetResponse.petStatus.ToString(), Is.EqualTo("available"));
            }
            else
                Assert.Fail();
        }

        [Test]
        public void FindWrongPet()
        {
            long petId = 1219911;
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/pet/" + petId, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse response = client.Execute(request);
            var FindUserResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

            Assert.That(FindUserResponse.type, Is.EqualTo("error"));
            Assert.That(FindUserResponse.message, Is.EqualTo("Pet not found"));
        }
    }
}
