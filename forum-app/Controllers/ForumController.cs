using forum_app.Data;
using forum_app.Models.ForumViewModel;
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

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
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
    }
}
