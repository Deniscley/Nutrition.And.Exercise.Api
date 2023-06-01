using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Borders.Messages
{
    public abstract class Command : Message
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
