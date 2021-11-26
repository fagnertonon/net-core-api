using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DGuard.Core.Data;

namespace DGuard.Aplicacao.API.Models
{
    public interface IServerRepository : IRepository<Server>
    {
        void CreateVideo(Video model);
        void DeleteVideo(Video model);
        Task<Video> GetVideoRegistrationForId(Guid serverId, Guid videoId);
        Task<Video> GetVideoStreamForId(Guid serverId, Guid videoId);

        Task<bool> ExistVideo(Guid VideoId);
        Task<IEnumerable<Video>> GetAllVideos(Guid serverId);
        void RecycleVideos(int day);
    }
}