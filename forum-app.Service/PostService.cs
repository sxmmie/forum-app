using forum_app.Data;
using forum_app.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.Service
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _ctx;

        public PostService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPost(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a single post, including the postUser, postForum, postReplies
        /// </summary>
        /// <param name="id">The post id</param>
        /// <returns></returns>
        public Post GetById(int id)
        {
            return _ctx.Posts.Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(replies => replies.User)
                .Include(post => post.Forum)
                .First();
        }

        public IEnumerable<Post> GetFilteredPost(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _ctx.Forums.Where(x => x.Id == id).First().Posts;
        }
    }
}
