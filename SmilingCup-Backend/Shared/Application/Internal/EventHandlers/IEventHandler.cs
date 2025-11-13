using SmilingCup_Backend.Shared.domain.model.events;

namespace SmilingCup_Backend.Shared.Application.Internal.EventHandlers;
using Cortex.Mediator.Notifications;


public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}