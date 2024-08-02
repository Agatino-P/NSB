using NServiceBus;

namespace NSP.api;
public class ApiCommandHandler :    IHandleMessages<ApiCommand>
{
    private readonly ILogger<ApiCommandHandler> _logger;

    public ApiCommandHandler(ILogger<ApiCommandHandler> logger)
    {
        this._logger = logger;
    }

    

    public async Task Handle(ApiCommand message, IMessageHandlerContext context)
    {
        _logger.LogWarning("Receided: {MessageName}, with payload {Payload}", nameof(ApiCommand), message.Text);
        await Task.Delay(TimeSpan.FromSeconds(3),CancellationToken.None);
    }
}