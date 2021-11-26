using System;
using System.Text.Json.Serialization;
using DGuard.Core.Messages;
using FluentValidation;

namespace DGuard.Aplicacao.API.Application.ServerCommand
{
    public class VideoCommand : Command
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public byte[] Content { get; set; }
        [JsonIgnore]
        public Guid ServerId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new VideoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class VideoValidation : AbstractValidator<VideoCommand>
        {
            public VideoValidation()
            {
                RuleFor(c => c.Description)
                    .NotEmpty()
                    .WithMessage("A descrição do video não foi informado");

                RuleFor(c => c.Content)
                      .NotEmpty()
                      .WithMessage("O conteudo do vídeo não foi informado");

                RuleFor(c => c.ServerId)
                      .NotEqual(Guid.Empty)
                      .WithMessage("O Servidor não é valido");
            }
        }
    }
    public class CreateVideoCommand : VideoCommand
    {
        public override bool IsValid()
        {
            if (!base.IsValid()) return ValidationResult.IsValid;

            ValidationResult = new CreatevideoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CreatevideoValidation : AbstractValidator<CreateVideoCommand>
        {
            public CreatevideoValidation()
            {
            }
        }
    }
    public class UpdateVideoCommand : VideoCommand
    {
        public override bool IsValid()
        {
            if (!base.IsValid()) return ValidationResult.IsValid;

            ValidationResult = new UpdateVideoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateVideoValidation : AbstractValidator<UpdateVideoCommand>
        {
            public UpdateVideoValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do vídeo não é inválido");
            }
        }
    }

    public class RemoveVideoCommand : VideoCommand
    {

        public override bool IsValid()
        {
            ValidationResult = new RemoveVideoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RemoveVideoValidation : AbstractValidator<RemoveVideoCommand>
        {
            public RemoveVideoValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do vídeo não é inválido");
            }
        }
    }
    public class RecicleVideoCommand : Command
    {
        public Guid Id { get; set; }

        public int DaysOfRecicle { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RecicleVideoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RecicleVideoValidation : AbstractValidator<RecicleVideoCommand>
        {
            public RecicleVideoValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do vídeo não é inválido");

                RuleFor(c => c.DaysOfRecicle)
                    .NotEmpty()
                    .WithMessage("Dias de reciclagem não foi informado");
            }
        }
    }
}