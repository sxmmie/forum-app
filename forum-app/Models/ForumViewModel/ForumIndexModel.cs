using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.Models.ForumViewModel
{
    public class ForumIndexModel
    {
        // A wrapper that wraps a collection of the ForumListingModel
        public IEnumerable<ForumListingViewModel> ForumListing { get; set; }

    }
}
