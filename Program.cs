using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ResourceGraph;
using Azure.ResourceManager.ResourceGraph.Models;

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

            var client = new ArmClient(new ClientSecretCredential(strTenant, strClientId, strClientSecret));
            var tenant = client.GetTenants().First();
            //Console.WriteLine($"{tenant.Id} {tenant.HasData}");
            var queryContent = new ResourceQueryContent(strQuery);
            var response = tenant.GetResources(queryContent);
            var result = response.Value;
            Console.WriteLine($"Count: {result.Data.ToString()}");
        }
    }
}