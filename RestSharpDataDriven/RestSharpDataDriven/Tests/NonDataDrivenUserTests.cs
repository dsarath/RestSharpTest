using NUnit.Framework;
using RestSharp;
using RestSharpDataDriven.Common;
using RestSharpDataDriven.DataTypes;
using Newtonsoft.Json;

namespace RestSharpDataDriven.Tests
{
    [TestFixture]
    class NonDataDrivenUserTests
    {
        private const string BASE_URL = "https://petstore.swagger.io/v2";

        [Test]
        public void NewUserRegister()
        {
            string jUser = "{ \"id\": 1991, \"username\": \"restsharp1\", \"firstName\": \"Restsharp\", \"lastName\": \"Test\", \"email\": \"restsharp@mailinator.com\", \"password\": \"blackcat123\", \"phone\": \"string\", \"userStatus\": 0}";
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/user", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(jUser);

            IRestResponse response = client.Execute(request);

            Assert.That(response.IsSuccessful);
        }

        [Test]
        public void LoginTest()
        {
            IRestResponse response = new Auth().Login();
            Assert.That(response.IsSuccessful);
        }

        [Test]
        public void LogoutTest()
        {
            IRestResponse response = new Auth().Logout();
            Assert.That(response.IsSuccessful);
        }

        [Test]
        public void FindUser()
        {
            string userName = "restsharp";
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/user/" + userName, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse response = client.Execute(request);
            var FindUserResponse = JsonConvert.DeserializeObject<User>(response.Content);

            if (response.IsSuccessful)//assert
            {
                Assert.That(FindUserResponse.userId, Is.EqualTo(1991));
                Assert.That(FindUserResponse.firstName, Is.EqualTo("Restsharp"));
            }
            else
                Assert.Fail();
        }

        [Test]
        public void FindWrongUser()
        {
            string userName = "sharp";
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("/user/" + userName, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse response = client.Execute(request);
            var FindUserResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

            Assert.That(FindUserResponse.type, Is.EqualTo("error"));
            Assert.That(FindUserResponse.message, Is.EqualTo("User not found"));
        }
    }
}
