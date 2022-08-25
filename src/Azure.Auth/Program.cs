using Microsoft.Identity.Client;

namespace Azure.Auth
{
    class Program
    {
        private const string _clientId = "05705a2a-b1c4-4d2a-b9a3-a7f60e6db727";
        private const string _tenantId = "5ec0b457-334c-4d27-91b0-d2a38b330948";

        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                .WithRedirectUri("https://oauth.pstmn.io/v1/callback")
                .Build();
            string[] scopes = { "api://05705a2a-b1c4-4d2a-b9a3-a7f60e6db727/Read" };
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}