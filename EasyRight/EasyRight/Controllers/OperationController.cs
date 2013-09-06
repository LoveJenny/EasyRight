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

        public ActionResult Index()
        {
            var opers = ERRepositry.Instance.GetOperations();

            return View(opers);
        }

    }
}
