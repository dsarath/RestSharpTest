using RestSharp;
using RestSharp.Authenticators;

namespace RestSharpDataDriven.Common
{
    class Auth
    {
        private const string BASE_URL = "https://petstore.swagger.io/v2";
        private const string USER_NAME = "restsharp";
        private const string PASSWORD = "blackcat123";

        public IRestResponse Login()
        {
            RestClient client = new RestClient(BASE_URL); //{ Authenticator = new HttpBasicAuthenticator(USER_NAME, PASSWORD) };
            RestRequest request = new RestRequest("/user/login?username=" + USER_NAME + "&password=" + PASSWORD, Method.GET) { RequestFormat = DataFormat.Json };
            IRestResponse response = client.Execute(request);

            return response;
        }

        public IRestResponse Login(string userName, string password)
        {
            RestClient client = new RestClient(BASE_URL); //{ Authenticator = new HttpBasicAuthenticator(USER_NAME, PASSWORD) };
            RestRequest request = new RestRequest("/user/login?username=" + userName + "&password=" + password, Method.GET) { RequestFormat = DataFormat.Json };
            IRestResponse response = client.Execute(request);

            return response;
        }

        public IRestResponse Logout()
        {
            RestClient client = new RestClient(BASE_URL); //{ Authenticator = new HttpBasicAuthenticator(USER_NAME, PASSWORD) };
            RestRequest request = new RestRequest("/user/logout") { RequestFormat = DataFormat.Json };
            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}
