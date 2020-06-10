using forum_app.Data;
using forum_app.Data.Models;
using forum_app.ViewModels.Forum;
using forum_app.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly IPostService _postService;

        public ForumController(IForumService forumService, IPostService postService)
        {
            _forumService = forumService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            // Get all forums
            // map properties of the FOrum object into instances of the FormViewModel
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingViewModel
                {
                    Id = forum.Id,
                    Name = forum.Title,
                    Description = forum.Description
                });

            var model = new ForumIndexModel
            {
                ForumListing = forums
            };

            return View(forums);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);  // grab a frum that matches the id passed

            // retrieve post from the DB that corresponds to this(forum-> id) particular forum
            /*var posts = _postService.GetPostsByForum(id);*/
            var posts = forum.Posts;

            // collection of posts
            var postListing = posts.Select(post => new PostListingViewModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Author = post.User.UserName,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post),
            });

            var model = new ForumTopicModel
            {
                Posts = postListing,
                Forum = BuildForumListing(forum)
            };

            return View(model);
        }

        private ForumListingViewModel BuildForumListing(Forum forum)
        {
            return new ForumListingViewModel
            {
                Id = forum.Id,
                Name = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
        }

        // Build out a ForumListing module frm the post
        private ForumListingViewModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return BuildForumListing(forum);
        }
    }
}
