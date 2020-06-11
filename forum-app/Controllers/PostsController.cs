using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Data;
using forum_app.Data.Models;
using forum_app.ViewModels.Post;
using forum_app.ViewModels.Post.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace forum_app.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IForumService _forumService;

        private static UserManager<ApplicationUser> _userManager;

        public PostsController(IPostService postService, IForumService forumService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Forum Id we want to create a post for</param>
        /// <returns></returns>
        public IActionResult Create(int id)
        {
            var forum = _forumService.GetById(id);

            var model = new NewPostModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);  // returns app user

            var post = BuildPost(model, user);

            await _postService.Add(post);

            return RedirectToAction("Index", "Post", post.Id);
        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user
            };
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