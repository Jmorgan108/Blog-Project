using System;
using Volo.Abp.Application.Dtos;

namespace BlogSpot.Authors
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }

    }
}
