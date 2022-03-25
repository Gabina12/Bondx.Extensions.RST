# Welcome to Bondx.Extensions.RST!

This Extension is for Response models for REST Api's.


# Usage

You just need to add one command in **Startup.cs** file

    services.AddRSTApiResponseExplorer();

after that you can use RSTActionResult<T> and RSTActionResult it's structured like IActionResult and has own filter to transform responses as HttpStatusCodes.
also we have RSTServiceBase class which can be used in service layer, it has abstract methods to return RSTOk | RSTBadRaquest | RSTNotFound and so on.