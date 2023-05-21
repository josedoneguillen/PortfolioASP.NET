using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.BlogPost;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Application.Extensions;
using System.Collections.Generic;

namespace Portfolio.Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ILogger<BlogPostService> logger;
        protected ServiceResult result;
        public BlogPostService(IBlogPostRepository blogPostRepository, ILogger<BlogPostService> logger)
        {
            this.blogPostRepository = blogPostRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getBlogPosts();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo los posts";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getBlogPosts(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo el post";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyBlogPost(BlogPostUpdateDto blogPostUpdateDto)
        {
            try
            {
                // Field Validations
                if (blogPostUpdateDto.Id == 0)
                {
                    this.result.Message = "Id del post a modificar es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (blogPostUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificación es requerido";
                    this.result.Success = false;
                    return result;
                }

                BlogPost blogPost = await this.blogPostRepository.GetEntityByID(blogPostUpdateDto.Id);


                if (blogPost == null)
                {
                    this.result.Message = "Este post no existe";
                    this.result.Success = false;
                    return result;
                }

                blogPost = blogPost.ConvertBlogPostUpdateDtoToBlogPost(blogPostUpdateDto);

                await this.blogPostRepository.Update(blogPost);

                this.result.Message = "Post actualizado correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando el post";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveBlogPost(BlogPostAddDto blogPostAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(blogPostAddDto.Title))
                {
                    this.result.Message = "Titulo es requerido";
                    this.result.Success = false;
                    return result;
                }

                BlogPost blogPost = blogPostAddDto.ConvertBlogPostAddDtoToBlogPost();


                await this.blogPostRepository.Save(blogPost);

                this.result.Message = "Post agregado correctamente";
                this.result.Data = blogPost.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando el post";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.BlogPostGetModel>> getBlogPosts(int? Id = null)
        {
            List<Models.BlogPostGetModel>? blogPosts = new List<Models.BlogPostGetModel>();
            try
            {
                blogPosts = (from blogPost in (await this.blogPostRepository.GetAll())
                               where blogPost.Id == Id || !Id.HasValue
                               select blogPost.CreateBlogPostGetModel()).ToList();
            }
            catch (Exception ex)
            {
                blogPosts = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo los posts", ex.ToString());
            }

            return blogPosts;
        }
    }
}
