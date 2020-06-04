using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.Data.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }

        // vritual -> makes it possible to lazyload the property, so when we ask for forums, we can include the post obj if we want
        // Post is a navigation property, to be lazy-loaded
        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
