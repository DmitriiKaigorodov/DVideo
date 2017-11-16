using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DVideo.Core.Models;
using DVideo.Core.Models.Queries;
using DVideo.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DVideo.Persistent
{
    public class VideosRepository : IVideosRepository
    {
        private readonly DvideoDbContext context;
        public VideosRepository(DvideoDbContext context)
        {
            this.context = context;

        }

        public void Add(Video video)
        {
            context.Videos.Add(video);
        }

        public async Task<Video> GetVideo(int id, bool includeUsersFeedback = false)
        {
            var query = context.Videos.Include( v => v.File).Include( v => v.Author)
                .ThenInclude( a => a.Avatar)
                .Include( v => v.Thumbnail).Include( v => v.Categories)
                .ThenInclude( c => c.Category);
    
            
            return await query.Include(v => v.UsersLiked).Include( v => v.UsersDisliked)
                .SingleOrDefaultAsync( v => v.Id == id);          
        }

        public async Task<QueryResult<Video>> GetVideos(VideoQuery filter)
        {
            var result = new QueryResult<Video>();
            var videos =   context.Videos.Include( v => v.File).Include(v => v.Author)
            .Include(v => v.Thumbnail).Include(v => v.UsersLiked).Include( v => v.UsersDisliked).AsQueryable();

            videos = filter.ApplyFiltering(videos);
            result.TotalItems = await videos.CountAsync();
            videos = filter.ApplyPaging(videos);    
            result.Entries = await videos.ToListAsync();
            
            return result;
        }


        public async Task<IEnumerable<Video>> GetVideosForCategory(Category category, bool includeRelated = false)
        {
            var query = context.Videos.Include( v => v.File).Include( v => v.Author)
                .Include( v => v.Thumbnail);
                          
            return await query.Include(v => v.UsersLiked).Include( v => v.UsersDisliked)
                .Where( v => v.Categories.Any( c => c.CategoryId == category.Id))
                .ToListAsync();              
        }

        public void Remove(Video video)
        {
           context.Videos.Remove(video);
        }
    }
}