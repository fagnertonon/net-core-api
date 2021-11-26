using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DGuard.Core.Mediator;
using DGuard.WebAPI.Core.Controllers;
using DGuard.WebAPI.Core.Usuario;
using DGuard.Aplicacao.API.Models;
using DGuard.Aplicacao.API.Application.ServerCommand;
using Microsoft.Extensions.Logging;

namespace DGuard.Aplicacao.API.Controllers
{
    [Route("api")]
    public class ServerController : MainController
    {
        private readonly IServerRepository _serverRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;
        private readonly ILogger<Server> _logger;
        public ServerController(IServerRepository serverRepository, IMediatorHandler mediator, IAspNetUser user, ILogger<Server> logger)
        {
            _serverRepository = serverRepository;
            _mediator = mediator;
            _user = user;
            _logger = logger;
        }
        /// <summary>
        /// Remover um servidor existente
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("server")]
        public async Task<IActionResult> CreateServer(CreateServerCommand server)
        {
            return CustomResponse(await _mediator.EnviarComando(server));
        }
        /// <summary>
        /// Remover um servidor existente
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("servers/{serverId}")]
        public async Task<IActionResult> DeleteServer(Guid serverId)
        {
            DeleteServerCommand server = new DeleteServerCommand(serverId);

            return CustomResponse(await _mediator.EnviarComando(server));
        }
        /// <summary>
        /// Listar todos os servidores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("servers")]
        public async Task<IActionResult> GetAll()
        {
            var servers = await _serverRepository.GetAll();

            return CustomResponse(servers);
        }
        /// <summary>
        /// Recuperar um servidor existente
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("servers/{serverId}")]
        public async Task<IActionResult> GetForId(Guid serverId)
        {
            var server = await _serverRepository.GetForId(serverId);

            return CustomResponse(server);
        }
        /// <summary>
        /// Checar disponibilidade de um servidor
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("server/avaliable/{serverId}")]
        public async Task<IActionResult> CheckStatusServer(Guid serverId)
        {
            var server = await _serverRepository.GetForId(serverId);

            var listen = server != null;


            return CustomResponse(listen);
        }
        /// <summary>
        /// Adicionar um novo vídeo à um servidor
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="createVideoCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("servers/{serverId}/videos")]
        public async Task<IActionResult> CreateVideo(CreateVideoCommand createVideoCommand)
        {
            //createVideoCommand.ServerId = serverId;

            return CustomResponse(await _mediator.EnviarComando(createVideoCommand));
        }
        /// <summary>
        /// Remover um vídeo existente
        /// </summary>
        /// <param name="removeVideoCommand"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("servers/{serverId}/video/{videoId}")]
        public async Task<IActionResult> RemoveVideo(Guid serverId, Guid videoId)
        {
            RemoveVideoCommand removeVideoCommand = new RemoveVideoCommand
            {
                Id = videoId,
                ServerId = serverId
            };

            return CustomResponse(await _mediator.EnviarComando(removeVideoCommand));
        }
        /// <summary>
        /// Recuperar dados cadastrais de um vídeo
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("servers/{serverId}/videos/{videoId}")]
        public async Task<IActionResult> GetVideoRegistration(Guid serverId, Guid videoId)
        {
            var videoRegistration = await _serverRepository.GetVideoRegistrationForId(serverId, videoId);
            return CustomResponse(videoRegistration);
        }
        /// <summary>
        /// Download do conteúdo binário de um vídeo
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("servers/{serverId}/videos/{videoId}/binary")]
        public async Task<IActionResult> GetVideoStream(Guid serverId, Guid videoId)
        {
            var funcionario = await _serverRepository.GetVideoStreamForId(serverId, videoId);
            return CustomResponse(funcionario);
        }
        /// <summary>
        /// Listar todos os vídeos de um servidor
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("servers/{serverId}/videos")]
        public async Task<IActionResult> GetAllVideos(Guid videoId)
        {
            var videos = await _serverRepository.GetAllVideos(videoId);
            return CustomResponse(videos);
        }
        /// <summary>
        /// Reciclar vídeos antigos Execução
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("servers/recycler/process/{days}")]
        public async Task<IActionResult> RecyclerVideosProcess(int days)
        {
            //RecicleVideoValidation command
            _serverRepository.RecycleVideos(days);

            return CustomResponse("Metodo não implementado");
        }
        /// <summary>
        /// Reciclar vídeos antigos Status
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("servers/recycler/status")]
        public async Task<IActionResult> RecyclerVideosStatus()
        {
            return CustomResponse("Metodo não implementado");
        }
    }
}