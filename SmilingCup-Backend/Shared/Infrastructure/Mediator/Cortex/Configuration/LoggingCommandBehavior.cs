using Cortex.Mediator.Commands;

namespace SmilingCup_Backend.Shared.infrastructure.mediator.cortex.configuration;

public class LoggingCommandBehavior<TCommand> 
    : ICommandPipelineBehavior<TCommand> where TCommand : ICommand
{
    public async Task Handle(
        TCommand command, 
        CommandHandlerDelegate next,
        CancellationToken ct)
    {
        // Log before/after
        await next();
    }
}