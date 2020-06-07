using forum_app.ViewModels.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.ViewModels.Post
{
    public class PostListingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public DateTime DatePosted { get; set; }

        /*public int ForumId { get; set; }
        public string ForumImageUrl { get; set; }
        public string ForumName { get; set; }*/

        public ForumListingViewModel Forum { get; set; }

        public int RepliesCount { get; set; }   // How many replies a post has
    }
}
