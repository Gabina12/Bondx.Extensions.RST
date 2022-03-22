# Welcome to Bondx.Extensions.RST.Mediator!

This Extension is for **MediatoR** to wrap it and set **CancelationToken** from HttpRequest.


# Usage

You just need to add one command in **Startup.cs** file

    services.AddRSTApiMediatRExplorer();

after that you can add Request
### Request
    public class GetWeatherForecastQuery : RSTRequest<IEnumerable<WeatherForecast>>
    {

    }
    
### RequestHandler
    public class GetWeatherForecastQueryHandler : RSTRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        protected override async Task<RSTActionResult<IEnumerable<WeatherForecast>>> HandleAsync(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var weather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
            return Ok(weather); //BadRequest("error_text")
        }
    }