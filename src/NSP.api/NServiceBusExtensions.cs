
namespace NSP.api;

public static class NServiceBusExtensions
{

    public static WebApplicationBuilder  ConfigureNSBAsync(this WebApplicationBuilder builder , string endpointName, params (Type messageType, string destination)[] routeDetails)
    {
        NServiceBus.EndpointConfiguration endpointConfiguration = new (endpointName);

        var persistence = endpointConfiguration.UsePersistence<LearningPersistence>();

        endpointConfiguration.SubscribeToPlatform();

        endpointConfiguration.UseSerialization<SystemJsonSerializer>();

        var transport = endpointConfiguration.UseTransport<LearningTransport>();
        var routing = transport.Routing();

        foreach (var (messageType, destination) in routeDetails)
        {
            routing.RouteToEndpoint(messageType, destination);
        }

        builder.UseNServiceBus(endpointConfiguration);

        return builder;
    }
    public static void SubscribeToPlatform(this EndpointConfiguration endpointConfiguration)
    {
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.AuditProcessedMessagesTo("audit");
        endpointConfiguration.SendHeartbeatTo("Particular.ServiceControl");

        var metrics = endpointConfiguration.EnableMetrics();
        metrics.SendMetricDataToServiceControl("Particular.Monitoring", TimeSpan.FromMilliseconds(500));
    }
}
