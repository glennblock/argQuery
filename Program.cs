using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Azure.Management.ResourceGraph;
using Microsoft.Azure.Management.ResourceGraph.Models;

namespace argQuery
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string strTenant = args[0];
            string strClientId = args[1];
            string strClientSecret = args[2];
            string strQuery = args[3];

            AuthenticationContext authContext = new AuthenticationContext("https://login.microsoftonline.com/" + strTenant);
            AuthenticationResult authResult = await authContext.AcquireTokenAsync("https://management.core.windows.net", new ClientCredential(strClientId, strClientSecret));
            ServiceClientCredentials serviceClientCreds = new TokenCredentials(authResult.AccessToken);

            ResourceGraphClient argClient = new ResourceGraphClient(serviceClientCreds);
            QueryRequest request = new QueryRequest();
            request.Query = strQuery;

            QueryResponse response = argClient.Resources(request);
            Console.WriteLine("Records: " + response.Count);
            Console.WriteLine("Data:\n" + response.Data);
        }
    }
}