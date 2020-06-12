using forum_app.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingViewModel> LatestPosts { get; set; }
    }
}
