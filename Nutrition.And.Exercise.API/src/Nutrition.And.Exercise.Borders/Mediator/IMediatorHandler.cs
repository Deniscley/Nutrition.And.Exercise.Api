using Nutrition.And.Exercise.Borders.Messages;
using FluentValidation.Results;

namespace Nutrition.And.Exercise.Borders.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventt) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
