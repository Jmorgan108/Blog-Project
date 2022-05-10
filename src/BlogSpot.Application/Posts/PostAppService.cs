using BlogSpot.Authors;
using BlogSpot.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BlogSpot.Posts
{
    [Authorize(BlogSpotPermissions.Posts.Default)]
    public class PostAppService : 
        CrudAppService<
            Post, //Post Entity
            PostDto, //Used to show Posts
            Guid, //Primary key of the post
            PagedAndSortedResultRequestDto,//Used for Paging and sorting  
            CreateUpdatePostsDto>, //Used to create update
        IPostAppService
    {

        private readonly IAuthorRepository _authorRepository;

        public PostAppService(IRepository<Post, Guid> repository, IAuthorRepository authorRepository) 
            : base(repository)
        {
            _authorRepository = authorRepository;
            GetPolicyName = BlogSpotPermissions.Posts.Default;
            GetListPolicyName = BlogSpotPermissions.Posts.Default;
            CreatePolicyName = BlogSpotPermissions.Posts.Create;
            UpdatePolicyName = BlogSpotPermissions.Posts.Edit;
            DeletePolicyName = BlogSpotPermissions.Posts.Delete;
        }

        public override async Task<PostDto> GetAsync(Guid id)
        {
            
            var queryable = await Repository.GetQueryableAsync();

            //LINQ to join authors and posts
            var query = from post in queryable
                        join author in await _authorRepository.GetQueryableAsync() on post.AuthorId equals author.Id
                        where post.Id == id
                        select new { post, author };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Post), id);
            }

            var PostDto = ObjectMapper.Map<Post, PostDto>(queryResult.post);
            PostDto.AuthorName = queryResult.author.Name;
            return PostDto;
        }

        public override async Task<PagedResultDto<PostDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from post in queryable
                        join author in await _authorRepository.GetQueryableAsync() on post.AuthorId equals author.Id
                        select new { post, author };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of PostDto objects
            var PostDtos = queryResult.Select(x =>
            {
                var PostDto = ObjectMapper.Map<Post, PostDto>(x.post);
                PostDto.AuthorName = x.author.Name;
                return PostDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<PostDto>(
                totalCount,
                PostDtos
            );
        }

        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        {
            var authors = await _authorRepository.GetListAsync();

            return new ListResultDto<AuthorLookupDto>(
                ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"post.{nameof(Post.Title)}";
            }

            if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "authorName",
                    "author.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"post.{sorting}";
        }
    }
}
