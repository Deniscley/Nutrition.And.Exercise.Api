using Nutrition.And.Exercise.Borders.Messages;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Borders.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventt) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
