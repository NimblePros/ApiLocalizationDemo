using Microsoft.AspNetCore.Mvc;

namespace DL.Backend.Web.Endpoints.LanguageEndpoints;

public class GreetingRequest
{
    [FromQuery]
    public string Name { get; set; }
}
