using System;
using DGuard.Core.Messages;
using FluentValidation;

namespace DGuard.Aplicacao.API.Application.ServerCommand
{
    public class ServerCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string IPPort { get; set; }
        public ServerCommand()
        {
        }
        public override bool IsValid()
        {
            ValidationResult = new ServerValidationBase().Validate(this);
            return ValidationResult.IsValid;
        }

        public class ServerValidationBase : AbstractValidator<ServerCommand>
        {
            public ServerValidationBase()
            {
                RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("O nome da servidor não foi informado");

                RuleFor(c => c.IP)
                        .NotEmpty()
                        .WithMessage("IP não foi informado");

                RuleFor(c => c.IP)
                        .Must(CommandValidationRules.HaveValidIP)
                        .WithMessage("O IP informado não é válido.");

                RuleFor(c => c.IPPort)
                        .NotEmpty()
                        .WithMessage("Porta IP não foi informado");
            }

        }
    }

    public class CreateServerCommand : ServerCommand
    {
        public override bool IsValid()
        {
            if (!base.IsValid()) return ValidationResult.IsValid;

            ValidationResult = new CreateEmpresaValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        public class CreateEmpresaValidation : AbstractValidator<ServerCommand>
        {
            public CreateEmpresaValidation()
            {

            }
        }
    }
  
    public class DeleteServerCommand : ServerCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new DeleteServerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public DeleteServerCommand(Guid id)
        {
            this.Id = id;
        }
        public class DeleteServerValidation : AbstractValidator<DeleteServerCommand>
        {
            public DeleteServerValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do servidor inválido");
            }
        }
    }
}