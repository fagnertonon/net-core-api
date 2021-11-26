using System.Threading.Tasks;
using FluentValidation.Results;
using DGuard.Core.Messages;

namespace DGuard.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}