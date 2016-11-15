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
            Notifications.ToList().ForEach(x =>
            {
                x.Send(message);
            });
        }

        public void Position(double lat, double lng)
        {
            JsonSerializer serialize = new JsonSerializer();
            string message = JsonConvert.SerializeObject(new { lat = lat, lng = lng });
            Notifications.ToList().ForEach(x =>
            {
                x.Send(message);
            });
        }
    }
}
