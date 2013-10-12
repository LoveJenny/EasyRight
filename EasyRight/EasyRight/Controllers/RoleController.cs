using EasyRight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyRight.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        public ActionResult Index()
        {
            var Roles = ERRepositry.Instance.GetRoles();

            return View(Roles);
        }


        //
        // GET: /Role/Details/5

        public ActionResult Details(Guid id)
        {
            var Role = ERRepositry.Instance.GetRoleById(id);
            return View(Role);
        }

        //
        // GET: /Role/Create

        public ActionResult Create()
        {
            ERRole Role = new ERRole();
            return View(Role);
        }

        //
        // POST: /Role/Create

        [HttpPost]
        public ActionResult Create(ERRole Role)
        {
            try
            {
                ERRepositry.Instance.AddRole(Role);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Role/Edit/5

        public ActionResult Edit(Guid id)
        {
            var Role = ERRepositry.Instance.GetRoleById(id);
            return View(Role);
        }

        //
        // POST: /Role/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, ERRole Role)
        {
            try
            {
                ERRepositry.Instance.UpdateRole(Role);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Role/Delete/5

        public ActionResult Delete(Guid id)
        {
            var Role = ERRepositry.Instance.GetRoleById(id);
            return View(Role);
        }

        //
        // POST: /Role/Delete/5

        [HttpPost]
        public ActionResult Delete(Guid id, ERRole Role)
        {
            try
            {
                ERRepositry.Instance.DeleteRole(Role);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SelectUserRoles(ERUser user)
        {
            var allRoles = ERRepositry.Instance.GetRoles();
            var userRoles = new List<ERRole>();
            if (user != null)
            {
                userRoles = ERRepositry.Instance.GetUserRoles(user);
            }

            ViewBag.AllRoles = allRoles;
            ViewBag.UserRoles = userRoles;

            return PartialView();
        }

    }
}
