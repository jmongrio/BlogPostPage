using BlogPostPage.Context;
using BlogPostPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogPostPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext _context;

        public HomeController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Post> postList = _context.Posts.ToList();

            return View(postList);
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Post? post = new();

            post = _context.Posts.FirstOrDefault(p => p.Id == id);

            return View(post);
        }

        public IActionResult Details(int id)
        {
            Post? post = new();

            post = _context.Posts.FirstOrDefault(p => p.Id == id);

            return View(post);
        }

        public IActionResult Delete(int id)
        {
            Post? post = new();

            post = _context.Posts.FirstOrDefault(p => p.Id == id);

            return View(post);
        }

        #region methods

        public IActionResult NewPost(Post post)
        {
            post.DatePost = DateTime.Now.ToString("dd/MM/yyyy");

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditPost(Post editedPost)
        {
            _context.Entry(editedPost).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeletePost(Post deletedPost)
        {
            _context.Entry(deletedPost).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}