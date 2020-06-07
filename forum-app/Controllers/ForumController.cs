using forum_app.Data;
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
            var forum = _forumService.GetById(id);

            // retrieve some postd from the DB that corresponds to this(forum) particular forum
            var posts = _postService.GetFilteredPosts(id);

            // collection of posts
            var postListing = new PostListingViewModel
            {

            };

            return View();
        }
    }
}
