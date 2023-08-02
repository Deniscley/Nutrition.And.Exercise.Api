using MediatR;
using Nutrition.And.Exercise.Application.Events;

namespace Nutrition.And.Exercise.Application.EventsHandlers
{
    public class ClientEventHandler : INotificationHandler<RegisteredCustomerEvent>
    {
        // Função para trabalhar com evento
        public Task Handle(RegisteredCustomerEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
