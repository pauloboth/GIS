using Entity;
using GIS_APP.WSHandler;
using Newtonsoft.Json;
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

        [HttpPost]
        public JsonResult Position(string message)
        {
            dynamic obj = JsonConvert.DeserializeObject(message);
            if (obj != null && obj.type != null)
            {
                if (obj.type == "mobile" && obj.position != null)
                {
                    ServiceProcessHandler handle = new ServiceProcessHandler();
                    handle.Position((double)obj.position.lat, (double)obj.position.lng);
                }
            }
            return Json(true);
        }
    }
}