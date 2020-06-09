using forum_app.ViewModels.Post.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.ViewModels.Post
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }

        //collection of post replies
        public IEnumerable<PostReplyModel> Replies { get; set; }
    }
}
