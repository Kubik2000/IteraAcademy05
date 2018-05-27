using Microsoft.AspNetCore.Mvc;
using BloggingPlatform.Api.Managers.Interfaces;
using BloggingPlatform.Dto;
using System;
using System.Collections.Generic;

namespace BloggingPlatform.Api.Controllers
{
    [Produces("application/json")]
    [Route("comment")]
    public class CommentsController : Controller
    {
        private readonly ICommentManager _commentManager;

        public CommentsController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        [HttpGet("post/{id}")]
        public IEnumerable<CommentDto> GetComments(Guid id)
        {
            return _commentManager.GetComments(id);
        }

        [HttpPost("post/{id}")]
        public CommentDto CreateComment([FromBody] CommentDto comment)
        {
            _commentManager.PostComment(comment);
            return comment;
        }
    }
}