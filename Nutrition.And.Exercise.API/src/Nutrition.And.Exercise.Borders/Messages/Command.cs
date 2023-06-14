﻿using FluentValidation.Results;
using MediatR;

namespace Nutrition.And.Exercise.Borders.Messages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Command() 
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValid()
        {
            throw new NotImplementedException();
        }
    }
}
