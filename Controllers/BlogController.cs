using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab7.Models;
using Lab7.Data;

namespace Lab7.Controllers
{
	 [ApiController]
    [Route("[controller]")]

	public class BlogController : ControllerBase
	{
		
		public BlogController()
		{
		
		}
	

		[HttpGet]
		public ActionResult<List<Blog>> GetAll() =>
		 BlogData.GetAll();

		[HttpGet("{id}")]
		public ActionResult<Blog> Get(int id)
		{
			var blog = BlogData.Get(id);

			if (blog == null)
				return NotFound();

			return blog;
		}

		[HttpPost]
		public IActionResult Create(Blog blog)
		{
			BlogData.Add(blog);
			return CreatedAtAction(nameof(Create), new { id = blog.BlogId }, blog);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Blog blog)
		{
			if (id != blog.BlogId)
				return BadRequest();

			var existingBlog = BlogData.Get(id);
			if (existingBlog is null)
				return NotFound();

			BlogData.Update(blog);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var blog = BlogData.Get(id);

			if (blog is null)
				return NotFound();

			BlogData.Delete(id);

			return NoContent();
		}
	}
}