using System.Threading.Tasks;
using FluentValidation.Results;
using DGuard.Core.Data;

namespace DGuard.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
        protected void AddError(string[] mensagens)
        {
            foreach (var msn in mensagens)
            {
                ValidationResult.Errors.Add(new ValidationFailure(string.Empty, msn));
            }
        }
        protected async Task<ValidationResult> PersistData(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}