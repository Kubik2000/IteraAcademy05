using BloggingPlatform.Dto;
using System.Collections.Generic;

namespace BloggingPlatform.Api.Managers.Interfaces
{
    public interface IAuthorManager
    {
        IEnumerable<AuthorDto> GetAuthors();
    }
}
