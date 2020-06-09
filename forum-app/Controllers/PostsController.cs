using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Data;
using forum_app.Data.Models;
using forum_app.ViewModels.Post;
using forum_app.ViewModels.Post.Reply;
using Microsoft.AspNetCore.Mvc;

namespace forum_app.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies
            };

            return View();
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies
                .Select(reply => new PostReplyModel
                {
                    Id = reply.Id,
                    AuthorId = reply.User.Id,
                    AuthorName = reply.User.UserName,
                    AuthorImageUrl = reply.User.ProfileImageUrl,
                    AuthorRating = reply.User.Rating,
                    Created = reply.Created,
                    ReplyContent = reply.Content
                });
        }
    }
}