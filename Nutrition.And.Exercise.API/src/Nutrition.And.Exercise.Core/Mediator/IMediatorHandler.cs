using Nutrition.And.Exercise.Core.Messages;
using FluentValidation.Results;

namespace Nutrition.And.Exercise.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventt) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
