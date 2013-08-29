using EasyRight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyRight.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            var users = ERRepositry.Instance.GetUsers();

            return View(users);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(Guid id)
        {
            var user = ERRepositry.Instance.GetUserById(id);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            ERUser user = new ERUser();
            return View(user);
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(ERUser user)
        {
            try
            {
                ERRepositry.Instance.AddUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(Guid id)
        {
            var user = ERRepositry.Instance.GetUserById(id);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, ERUser user)
        {
            try
            {
                ERRepositry.Instance.UpdateUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(Guid id)
        {
            var user = ERRepositry.Instance.GetUserById(id);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(Guid id, ERUser user)
        {
            try
            {
                ERRepositry.Instance.DeleteUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
