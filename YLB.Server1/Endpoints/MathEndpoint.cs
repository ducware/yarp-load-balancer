
using Microsoft.AspNetCore.Mvc;

namespace YLB.Server1.Endpoints
{
    public class MathEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder endpoint, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            var mathRoute = endpoint.MapGroup("v1/math").WithTags("Maths");

            mathRoute.MapGet("add", (HttpContext httpContext, [FromQuery] int numberOne, int numberTwo) => {

                var serverUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host.Value}";
                var result = $"Response from {serverUrl}, with result: {numberOne + numberTwo}";

                return Results.Ok(result);
            }).WithName("add-two-numbers").Produces<IEnumerable<string>>(200);
        }
    }
}
