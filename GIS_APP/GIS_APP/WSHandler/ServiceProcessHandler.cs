using Entity;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.WebSockets;

namespace GIS_APP.WSHandler
{
    public class ServiceProcessHandler : WebSocketHandler
    {
        private static WebSocketCollection Notifications = new WebSocketCollection();
        //public string Domain;
        public HttpSessionState Session { get; set; }

        //Estabelece a conexão de socket
        public override void OnOpen()
        {
            //this.Domain = HttpContext.Current.Request.Url.Authority;
            Notifications.Add(this);
            Notifications.Broadcast("A conexão foi estabelecida!");
        }

        //CallBack do Fechamento da conexão
        public override void OnClose()
        {
            Notifications.Remove(this);
            Notifications.Broadcast("A conexão foi interrompida!");
        }

        public override void OnMessage(string message)
        {
            dynamic obj = JsonConvert.DeserializeObject(message);
            if (obj != null && obj.type != null)
            {
                if (obj.type == "mobile" && obj.position != null)
                    Position(new Position { lat = obj.position.lat, lng = obj.position.lng });
            }
        }

        public void Position(Position position)
        {

            long area_id = 1;
            MyDbContext context = new MyDbContext();
            long id = 1;
            try { id = context.Positions.Max(x => x.id) + 1; }
            catch { }
            long point_id = 1;
            try { point_id = context.Points.Max(x => x.id) + 1; }
            catch { }
            if (position.lsPoints != null)
                position.lsPoints.ForEach(x =>
                {
                    x.pos_id = id;
                    x.id = point_id;
                    point_id++;
                });
            position.id = id;
            position.area_id = area_id;

            context.Positions.Add(position);
            context.SaveChanges();

            string message = JsonConvert.SerializeObject(position);
            Notifications.ToList().ForEach(x =>
            {
                x.Send(message);
            });
        }
    }
}