using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cheetah_Transport.Controllers
{
    public class FrontpageController : Controller
    {
        public ActionResult Start()
        {
            return View();
        }
    }
}