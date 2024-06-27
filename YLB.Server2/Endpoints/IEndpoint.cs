namespace YLB.Server2.Endpoints
{
    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder endpoint, IConfiguration configuration, IHttpContextAccessor httpContextAccessor);
    }
}
