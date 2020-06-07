using forum_app.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.ViewModels.Forum
{
    public class ForumTopicModel
    {
        public ForumListingViewModel Forum { get; set; }    // Get basic info about the forum
        public IEnumerable<PostListingViewModel> Posts { get; set; }
    }
}
