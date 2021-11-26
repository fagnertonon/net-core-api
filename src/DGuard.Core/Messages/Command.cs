using System;
using System.Text.Json.Serialization;
using FluentValidation.Results;
using MediatR;

namespace DGuard.Core.Messages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}