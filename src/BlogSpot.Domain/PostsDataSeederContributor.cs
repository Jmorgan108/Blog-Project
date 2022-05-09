using BlogSpot.Authors;
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
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;

        public PostDataSeederContributor(IRepository<Post, Guid> postRepository, IAuthorRepository authorRepository,
            AuthorManager authorManager)
        {
            _postRepository = postRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
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

            if (await _authorRepository.GetCountAsync() <= 0)
            {
                await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "Stan Lee",
                        new DateTime(1958, 06, 25),
                        "Stan Lee was an American comic book writer, editor, publisher, and producer. He rose through the ranks of a family-run business called Timely Publications"
                    )
                );

                await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "Edgar Allan Poe",
                        new DateTime(1809, 03, 11),
                        "Edgar Allan Poe was an American writer, poet, editor, and literary critic. Poe is best known for his poetry and short stories, particularly his tales of mystery and the macabre."
                    )
                );
            }
        }
    }
}