using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GIS_APP.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        MyDbContext context;
        public MapController()
        {
            context = new MyDbContext();
        }

        public ActionResult Index(long id = 0)
        {
            if (id == 0)
                id = 1;
            Area area = context.Areas.Where(x => x.id == id).FirstOrDefault();
            return View(area);
        }

        public ActionResult Mobile()
        {
            return View();
        }
    }
}