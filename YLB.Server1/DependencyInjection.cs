using System.Reflection;
using YLB.Server1.Endpoints;

namespace YLB.Server1
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, WebApplication app, IHttpContextAccessor httpContextAccessor)
        {
            var configuration = app.Configuration;

            // Config for Minimal APIs
            var assembly = Assembly.GetExecutingAssembly();

            var endpointsCollection = assembly
                .GetTypes()
                .Where(t => !t.IsInterface && t.GetInterfaces().Contains(typeof(IEndpoint)));

            foreach (var endpointType in endpointsCollection)
            {
                var map = endpointType.GetMethod(nameof(IEndpoint.Map));
                if (map != null)
                {
                    var instance = Activator.CreateInstance(endpointType);
                    map.Invoke(instance, new object[] { app, configuration, httpContextAccessor });
                }
            }

            return services;
        }

    }
}
