using Ardalis.ApiEndpoints;
using LocalizationDemo.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;

namespace DL.Backend.Web.Endpoints.LanguageEndpoints;
public class Greeting : EndpointBaseAsync
    .WithRequest<GreetingRequest>
    .WithActionResult<GreetingResponse>
{
    private readonly IStringLocalizer<Messages> _localizer;
    private readonly ILogger<Greeting> _logger;

  public Greeting(
      IStringLocalizer<Messages> localizer,
    ILogger<Greeting> logger)
  {
        _localizer = localizer;
        _logger = logger;
  }

  [HttpGet("/Greeting")]
  [SwaggerOperation(
      Summary = "Returns a localized greeting",
      Description = "Returns a localized greeting",
      OperationId = "DL.Greeting",
      Tags = new[] { "LanguageEndpoints" })
  ]
    public override async Task<ActionResult<GreetingResponse>> HandleAsync([FromQuery]GreetingRequest request,
      CancellationToken cancellationToken = default)
    {
        var localizedString = _localizer["Greeting"];

        _logger.LogDebug("Localized String: name={0};value={1};\nresourceNotFound={2};searchedLocation={3}", localizedString.Name,
          localizedString.Value, localizedString.ResourceNotFound, localizedString.SearchedLocation);

        var response = new GreetingResponse { 
            GreetingFormatString = localizedString.Value,
            Greeting = String.Format(localizedString.Value, request.Name)
            };

        return Ok(response);
    }

}
