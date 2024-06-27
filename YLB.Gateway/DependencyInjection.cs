namespace YLB.LoadBalancer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // For reverse proxy
            services.AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"));

            return services;
        }
    }

    public static class EndpointRouteBuilderExtensions
    {
        public static void MapEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var app = endpoints as WebApplication;
            if (app == null)
            {
                throw new InvalidOperationException("Unable to map endpoints. The IEndpointRouteBuilder instance is not a WebApplication.");
            }

            // Map reverse proxy
            app.MapReverseProxy();
        }
    }
}
