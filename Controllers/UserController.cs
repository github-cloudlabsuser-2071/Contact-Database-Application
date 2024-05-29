using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>() 
            {
                new User { Id = 1, Name = "User 1", Email = "user1@example.com" },
                new User { Id = 2, Name = "User 2", Email = "user2@example.com" },
                new User { Id = 3, Name = "User 3", Email = "user3@example.com" },
                new User { Id = 4, Name = "User 4", Email = "user4@example.com" },
                new User { Id = 5, Name = "User 5", Email = "user5@example.com" },
                new User { Id = 6, Name = "User 6", Email = "user6@example.com" },
                new User { Id = 7, Name = "User 7", Email = "user7@example.com" },
                new User { Id = 8, Name = "User 8", Email = "user8@example.com" },
                new User { Id = 9, Name = "User 9", Email = "user9@example.com" },
                new User { Id = 10, Name = "User 10", Email = "user10@example.com" }
            };
        // GET: User
        public ActionResult Index()
        {
            var model = TempData["FilteredUsers"] as List<User> ?? userlist;
            return View(model);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            userlist.Add(user);
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return HttpNotFound();
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // Add other properties as needed
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            userlist.Remove(user);
            return RedirectToAction("Index");
        }
        // GET: User/Search
        public ActionResult Search(string searchString)
        {
            var lowerCaseSearchString = searchString.ToLower();
            var filteredUsers = userlist.Where(u => u.Name.ToLower().Contains(lowerCaseSearchString) || u.Email.ToLower().Contains(lowerCaseSearchString)).ToList();
            TempData["FilteredUsers"] = filteredUsers;
            TempData["SearchString"] = searchString;
            return RedirectToAction("Index");
        }
    }
}