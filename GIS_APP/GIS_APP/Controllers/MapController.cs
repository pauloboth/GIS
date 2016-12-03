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

        public ActionResult Mobile(string id)
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
                    Position position = new Position { lat = (double)obj.position.lat, lng = (double)obj.position.lng };
                    position.lsPoints = new List<Point>();
                    if (obj.points != null)
                    {
                        position.lsPoints.Add(new Point { lat = (double)obj.points.p1.lat, lng = (double)obj.points.p1.lng });
                        position.lsPoints.Add(new Point { lat = (double)obj.points.p2.lat, lng = (double)obj.points.p2.lng });
                        position.lsPoints.Add(new Point { lat = (double)obj.points.p3.lat, lng = (double)obj.points.p3.lng });
                        position.lsPoints.Add(new Point { lat = (double)obj.points.p4.lat, lng = (double)obj.points.p4.lng });
                        //dynamic[] lsPoint = (dynamic[])obj.points;
                        //lsPoint.ToList().ForEach(x =>
                        //{
                        //    position.lsPoints.Add(new Point { lat = (double)x.lat, lng = (double)x.lng });
                        //});
                    }
                    handle.Position(position);
                }
            }
            return Json(true);
        }
    }
}