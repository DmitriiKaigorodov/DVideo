using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DVideo.Core.Extentions;
using DVideo.Core.FileStorage;
using DVideo.Core.Models;
using DVideo.Core.Models.Queries;
using DVideo.Core.Models.Resources;
using DVideo.Core.Models.Resources.Queries;

namespace DVideo.Core.Mapping
{
    public class DvideoMappingProfile : Profile
    {
        public DvideoMappingProfile()
        {
            CreateMap<Comment, CommentResource>();
            CreateMap<CommentResource, Comment>();

            CreateMap<UploadedFileResource, Thumbnail>();
            CreateMap<Thumbnail, UploadedFileResource>();

            CreateMap<VideoFile, VideoFileResource>();
            CreateMap<VideoFileResource, VideoFile>();
            CreateMap<SaveVideoFileResource, VideoFile>()
            .ForMember( v => v.Path, opt => opt.Ignore())
            .ForMember( v => v.Url, opt => opt.Ignore());

            CreateMap<Category, KeyValuePairResource>();
            CreateMap<KeyValuePairResource, Category>();

            CreateMap<UploadedFile, Thumbnail>();
            CreateMap<UploadedFile, VideoFile>();
            CreateMap<UploadedFile, Avatar>();

            CreateMap<Video, MainInfoVideoResourse>()
            .ForMember( vr => vr.Thumbnail, opt => opt.MapFrom(v => v.Thumbnail.Url))
            .ForMember( vr => vr.VideoSource, opt => opt.MapFrom(v => v.File.Url))
            .ForMember( vr => vr.DurationTime, opt => opt.MapFrom( v => 
                TimeSpan.FromSeconds(v.File.DurationInSeconds).ToString()
            ));

            CreateMap<Video, VideoResource>()
            .ForMember( vr => vr.Categories, opt => opt.Ignore())
            .ForMember( vr => vr.Likes, opt => opt.MapFrom( v => v.UsersLiked.Count ))
            .ForMember( vr => vr.Dislikes, opt => opt.MapFrom( v => v.UsersDisliked.Count ))
            .AfterMap( (v , vr) =>
            {               
                vr.Categories.Clear();

                foreach( CategoryVideo categoryVideo  in v.Categories)
                        vr.Categories.Add( new KeyValuePairResource()
                        {
                            Id = categoryVideo.CategoryId,
                            Name = categoryVideo.Category.Name
                            
                        });           
            });
            CreateMap<UsersLikedVideos, MainInfoVideoResourse>()
            .ForMember( vr => vr.Id, opt=> opt.MapFrom( ulv => ulv.VideoId))
            .ForMember( vr => vr.Title, opt=> opt.MapFrom( ulv => ulv.Video.Title))
            .ForMember( vr => vr.Thumbnail, opt => opt.AllowNull())
            .ForMember( vr => vr.Thumbnail, opt => opt.MapFrom( ulv => ulv.Video.Thumbnail.Path));
            CreateMap<SaveVideoResource, Video>()
            .ForMember( svr => svr.Categories, opt => opt.Ignore())
            .ForMember( svr => svr.Id, opt=> opt.Ignore())
            .AfterMap( ( svr, video )=>
            {
                List<CategoryVideo> removedCategories = video.Categories
                .Where(categoryVideo => !svr.Categories.Contains(categoryVideo.CategoryId)).ToList();

                foreach(var categoryVideo in removedCategories)
                {
                    video.Categories.Remove(categoryVideo);
                }

                List<int> addedCategories = svr.Categories
                .Where( categoryId => !video.Categories.Any( cv => cv.CategoryId == categoryId)).ToList();


                foreach(var categoryId in addedCategories)
                {
                    video.Categories.Add(new CategoryVideo
                    {
                        CategoryId = categoryId
                    });
                }
            });         

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

            CreateMap<CategoryQuery, CategoryQueryResource>();
            CreateMap<CategoryQueryResource, CategoryQuery>();
            CreateMap<VideoQueryResource, VideoQuery>();
            CreateMap<User, UserResource>();
            CreateMap<User, KeyValuePairResource>();
            CreateMap<User, MainInfoUserResource>()
            .ForMember( ur => ur.Avatar, opt => opt.AllowNull())
            .ForMember( ur => ur.Avatar, opt => opt.MapFrom(user => user.Avatar.Path));   
            CreateMap<UsersLikedVideos, MainInfoUserResource>()
            .ForMember( vr => vr.Id, opt=> opt.MapFrom( ulv => ulv.UserId))
            .ForMember( vr => vr.Name, opt=> opt.MapFrom( ulv => ulv.User.Name))
            .ForMember( vr => vr.Avatar, opt => opt.AllowNull())
            .ForMember( vr => vr.Avatar, opt => opt.MapFrom( ulv => ulv.User.Avatar.Path));
            CreateMap<SaveUserResource, User>()
            .ForMember( u => u.Password, opt => opt.Ignore())
            .AfterMap( (ur, u) =>
            {
               u.Password = ur.Password.ToSha256();
            });



        }
    }
}