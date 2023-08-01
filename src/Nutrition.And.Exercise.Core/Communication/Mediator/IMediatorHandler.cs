using Nutrition.And.Exercise.Core.Messages;
using FluentValidation.Results;
using Nutrition.And.Exercise.Core.Messages.CommonMessages.Notifications;

namespace Nutrition.And.Exercise.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventt) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
