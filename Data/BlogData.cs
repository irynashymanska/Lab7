using Lab7.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab7.Data
{
    public static class BlogData 
    {
        static List<Blog> Blogs { get; }
        static int nextId = 3;
        static BlogData()
        {
         Blogs = new List<Blog>
            {
                new Blog { BlogId = 1, Name = "Anna",  SurName = "Pogiba", },
                new Blog { BlogId = 2, Name = "Olena",  SurName = "Pelena", }
            };
        }

        public static List<Blog> GetAll() => Blogs;

        public static Blog Get(int id) => Blogs.FirstOrDefault(b => b.BlogId == id);

        public static void Add(Blog blog)
        {
            blog.BlogId = nextId++;
         Blogs.Add(blog);
        }

        public static void Delete(int id)
        {
            var blog = Get(id);
            if(blog is null)
                return;

         Blogs.Remove(blog);
        }

        public static void Update(Blog blog)
        {
            var index = Blogs.FindIndex(b => b.BlogId == blog.BlogId);
            if(index == -1)
                return;

         Blogs[index] = blog;
        }
    }
}