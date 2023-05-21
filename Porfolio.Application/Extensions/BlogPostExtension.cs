using System;
using Portfolio.Application.Dtos.BlogPost;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Extensions
{
    public static class BlogPostExtension
    {
        public static BlogPost ConvertBlogPostAddDtoToBlogPost(this BlogPostAddDto blogPostAddDto)
        {
            return new BlogPost()
            {
                Title = blogPostAddDto.Title,
                Slug = blogPostAddDto.Slug,
                Content = blogPostAddDto.Content,
                ImageUrl = blogPostAddDto.ImageUrl,
                PublishDate = blogPostAddDto.PublishDate,
                IdUserCreate = blogPostAddDto.IdUser,
                IsPublished = blogPostAddDto.IsPublished,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };
        }
        public static BlogPost ConvertBlogPostUpdateDtoToBlogPost(this BlogPost blogPost, BlogPostUpdateDto blogPostUpdateDto)
        {
            blogPost.Title = blogPostUpdateDto.Title ?? blogPost.Title;
            blogPost.Slug = blogPostUpdateDto.Slug ?? blogPost.Slug;
            blogPost.Content = blogPostUpdateDto.Content ?? blogPost.Content;
            blogPost.ImageUrl = blogPostUpdateDto.ImageUrl ?? blogPost.ImageUrl;
            blogPost.PublishDate = blogPostUpdateDto.PublishDate != null ? blogPostUpdateDto.PublishDate : blogPost.PublishDate;
            blogPost.IdUserModification = blogPostUpdateDto.IdUser;
            blogPost.IsPublished = blogPostUpdateDto.IsPublished.HasValue ? blogPostUpdateDto.IsPublished.Value : blogPost.IsPublished;
            blogPost.ModificationDate = DateTime.Now;
            blogPost.IsDeleted = blogPostUpdateDto.IsDeleted.HasValue ? blogPostUpdateDto.IsDeleted.Value : blogPost.IsDeleted;
            blogPost.DeletedDate = (blogPostUpdateDto.IsDeleted.HasValue && blogPostUpdateDto.IsDeleted == true) ? DateTime.Now : blogPost.DeletedDate;

            return blogPost;
        }
        public static BlogPostGetModel CreateBlogPostGetModel(this BlogPost blogPost)
        {
            return new Models.BlogPostGetModel()
            {
                Title = blogPost.Title,
                Slug = blogPost.Slug,
                Content = blogPost.Content,
                ImageUrl = blogPost.ImageUrl
        };

        }
    }
}
