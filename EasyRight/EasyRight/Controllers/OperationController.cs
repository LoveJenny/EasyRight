using EasyRight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyRight.Controllers
{
    public class OperationController : Controller
    {
        //
        // GET: /Operation/

        public ActionResult Index(Guid rid)
        {
            var role = ERRepositry.Instance.GetRoleById(rid);
            var roleOpers = role.GetOperations().Select(o => o.Id);

            var opers = ERRepositry.Instance.GetOperations();
            foreach (var oper in opers)
            {
                if (roleOpers.Contains(oper.Id))
                {
                    oper.IsSelected = true;
                }
            }

            return View(opers);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Guid rid = Guid.Parse(Request.QueryString["rid"]);
            var role = ERRepositry.Instance.GetRoleById(rid);

            var opers = ERRepositry.Instance.GetOperations();
            var roleOperations = opers.Where(o => form.Keys.Cast<string>()
                                                            .Select(s => Guid.Parse(s))
                                                            .Contains(o.Id)).ToList();
            
            ERRepositry.Instance.RefreshRoleOperations(role, roleOperations);

            ViewBag.Message = "Operation Success";

            return Index(rid);
        }
    }
}
