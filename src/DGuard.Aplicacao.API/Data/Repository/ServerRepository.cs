using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DGuard.Aplicacao.API.Models;
using System.Linq;

namespace DGuard.Aplicacao.API.Data.Repository
{
    public class ServerRepository : RepositoryBase<Server>, IServerRepository
    {
        private readonly ApplicationContext _context;

        public ServerRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void CreateVideo(Video model)
        {
            _context.Video.Add(model);
        }

        public void DeleteVideo(Video model)
        {
            _context.Video.Remove(model);
        }

        public async Task<bool> ExistVideo(Guid VideoId)
        {
            return await _context.Video.AnyAsync(x => x.Id == VideoId);
        }

        public async Task<IEnumerable<Video>> GetAllVideos(Guid serverId)
        {
            return _context.Video.Where(x => x.ServerId == serverId);
        }

        public async Task<Video> GetVideoRegistrationForId(Guid serverId, Guid videoId)
        {
            return await _context.Video.Select(x => new Video
            {
                Id = x.Id,
                ServerId = x.ServerId,
                Description = x.Description
            })
            .Where(x => x.ServerId == serverId && x.Id == videoId)
            .FirstOrDefaultAsync();
        }

        public async Task<Video> GetVideoStreamForId(Guid serverId, Guid videoId)
        {
            return await _context.Video.Select(x => new Video
            {
                Id = x.Id,
                Content = x.Content
            })
            .Where(x => x.ServerId == serverId && x.Id == videoId)
            .FirstOrDefaultAsync();
        }

        public void RecycleVideos(int day)
        {
            var DateRemove = DateTime.UtcNow.AddDays(-day);

            var videosRemove = _context.Video.Where(x => x.RegistrationDate < DateRemove);

            _context.Video.RemoveRange(videosRemove);
        }
    }
}