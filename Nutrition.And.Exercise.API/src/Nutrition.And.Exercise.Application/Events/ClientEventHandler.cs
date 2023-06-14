using MediatR;

namespace Nutrition.And.Exercise.Application.Events
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
