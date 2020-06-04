using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        // Navigation property
        public virtual ApplicationUser User { get; set; }   // Who wrote the post
        public virtual Forum Forum { get; set; }  // Each post related and posted to a particular forum
        public virtual IEnumerable<PostReply> Replies { get; set; }  // Associate a series of replies to each post
    }
}
