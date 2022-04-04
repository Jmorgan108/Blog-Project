using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BlogSpot
{
    public class PostDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Post, Guid> _postRepository;

        public PostDataSeederContributor(IRepository<Post, Guid> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _postRepository.GetCountAsync() <= 0)
            {
                await _postRepository.InsertAsync(
                    new Post
                    {
                        Title = "1973",
                        Content = "This is by far one of best songs ever made",
                        PublishDate = new DateTime(2004, 6, 8),
                        Tags = TagType.Life,
                        Likes = 0
                    },
                    autoSave: true
                );

                await _postRepository.InsertAsync(
                    new Post
                    {
                        Title = "C Hashtag is the best",
                        Content = "We all love C#,We all love C#,We all love C#,We all love C#,We all love C#,We all love C#,We all love C#,We all love C#," +
                        "We all love C#,We all love C#,We all love C#,We all love C#,We all love C#,We all love C#",
                        PublishDate = new DateTime(2022, 11, 11),
                        Tags = TagType.Tech,
                        Likes = 23
                    },
                    autoSave: true
                );
            }
        }
    }
}