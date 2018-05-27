﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BloggingPlatform.Api.Managers.Interfaces;
using BloggingPlatform.Dto;

namespace BloggingPlatform.Api.Controllers
{
    [Produces("application/json")]
    [Route("post")]
    public class PostsController : Controller
    {
        private readonly IPostManager _postManager;

        public PostsController(IPostManager postManager)
        {
            _postManager = postManager;
        }
        
        [HttpGet]
        public IEnumerable<PostDto> GetPosts()
        {
            return _postManager.GetPosts();
        }
        
        [HttpGet("{id}")]
        public PostDto GetPostById([FromRoute] Guid id)
        {
            return _postManager.GetPostById(id);
        }

        [HttpGet("findByAuthor")]
        public IEnumerable<PostDto> GetPostsByAuthor(Guid author)
        {
            return _postManager.GetPostsByAuthor(author);          
        }

        [HttpGet("findByCategory")]
        public IEnumerable<PostDto> GetPostsByCategory(Guid category)
        {
            return _postManager.GetPostsByCategory(category);
        }       
        
        [HttpPost]
        public PostDto PostPosts([FromBody] PostDto posts)
        {
            _postManager.SavePost(posts);
            return posts;
        }        
    }
}