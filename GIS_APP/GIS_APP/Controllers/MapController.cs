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
        public ActionResult Index()
        {
            try
            {
                Context context = new Context();
                List<Position> lsP = context.Positions.ToList();
            }
            catch (Exception ex) { }
            return View();
        }
    }
}