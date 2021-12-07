using Lab7.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab7.Data
{ public interface IBlogData
    {
        List<Blog> GetAll();
        Blog Get(int id);
        void Add(Blog b);
        void Delete(int id);
        Blog Update(Blog b);

    }
}