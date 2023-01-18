# argQuery 

This is an updated version of the Azure [quickstart](https://learn.microsoft.com/en-us/azure/governance/resource-graph/first-query-dotnet) for querying the Resource Graph, which uses the newer SDK and APIs.

# Version
.NET 6.0

# Packages / Deprecation

The existing document uses classes within the code that have been deprectated and it is missing packages that are required. It also has pacakges that are not needed.

The updated sample uses these packages

* `Azure.Identity`
* `Azure.ResourceManager`
* `Azure.ResourceManager.ResouceGraph`

# How the code works

THe code had to be completely rewritten to use the new APIs:

* `ArmClient` is constructed with `ClientSecretCredential` in order to connect to Azure. Default credentials / managed can also be used.
* The `TenantResource` is retrieved (this may need to be changed as I am only pulling the first)
* `ResourceQueryContent` is constructed with the Kusto query.
* `TenantResource.GetResources()` is called to run the query.
