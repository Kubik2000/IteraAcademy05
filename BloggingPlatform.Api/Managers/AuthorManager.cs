using AutoMapper;
using BloggingPlatform.Api.Managers.Interfaces;
using BloggingPlatform.Db.Model;
using BloggingPlatform.Dto;
using System.Collections.Generic;

namespace BloggingPlatform.Api.Managers
{
    public class AuthorManager : IAuthorManager
    {
        private readonly BloggingPlatformContext _context;
        private readonly IMapper _mapper;

        public AuthorManager(BloggingPlatformContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            var authors = _context.Authors;
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }
    }
}
