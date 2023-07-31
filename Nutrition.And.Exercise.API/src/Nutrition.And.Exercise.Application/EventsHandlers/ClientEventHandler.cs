using MediatR;
using Nutrition.And.Exercise.Application.Events;

namespace Nutrition.And.Exercise.Application.EventsHandlers
{
    public class ClientEventHandler : INotificationHandler<RegisteredCustomerEvent>
    {
        public Task Handle(RegisteredCustomerEvent notification, CancellationToken cancellationToken)
        {
            // Enviar evento de confirmação
            return Task.CompletedTask;
        }
    }
}
