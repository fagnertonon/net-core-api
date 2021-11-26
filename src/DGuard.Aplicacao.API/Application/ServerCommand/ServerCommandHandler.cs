using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DGuard.Core.Messages;
using DGuard.Aplicacao.API.Models;
using System;
using System.Collections.Generic;
using DGuard.Core.DomainObjects;
using System.Linq;

namespace DGuard.Aplicacao.API.Application.ServerCommand
{
    public class ServerCommandHandler : CommandHandler,
        IRequestHandler<CreateServerCommand, ValidationResult>,
        IRequestHandler<DeleteServerCommand, ValidationResult>,
        IRequestHandler<CreateVideoCommand, ValidationResult>,
        IRequestHandler<UpdateVideoCommand, ValidationResult>,
        IRequestHandler<RemoveVideoCommand, ValidationResult>
    {
        private readonly IServerRepository _serverRepository;

        public ServerCommandHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<ValidationResult> Handle(CreateServerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var server = new Server
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                IP = new IP(request.IP).Number,
                IPPort = request.IPPort
            };

            var serverExistente = await _serverRepository.Query(x=>x.Name == request.Name 
                                                                || (x.IP == server.IP && x.IPPort == server.IPPort));

            if (serverExistente.Any())
            {
                AddError("Este nome de servidor já está em uso.");
                return ValidationResult;
            }

            _serverRepository.Create(server);

            return await PersistData(_serverRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(DeleteServerCommand request, CancellationToken cancellationToken)
        {
            var server = await _serverRepository.GetForId(request.Id);

            if (server == null)
            {
                AddError("Servidor não encontrada");
                return ValidationResult;
            }

            _serverRepository.Delete(server);

            return await PersistData(_serverRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {

            return await PersistData(_serverRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {

            return await PersistData(_serverRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveVideoCommand request, CancellationToken cancellationToken)
        {
            return await PersistData(_serverRepository.UnitOfWork);
        }
    }
}