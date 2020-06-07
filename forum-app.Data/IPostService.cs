﻿using forum_app.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_app.Data
{
    public interface IPostService
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPost(string searchQuery);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPost(int id, string newContent);
        //Task AddReply(PostReply reply);
    }
}
