namespace YLB.Server3.Endpoints
{
    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder endpoint, IConfiguration configuration, IHttpContextAccessor httpContextAccessor);
    }
}
