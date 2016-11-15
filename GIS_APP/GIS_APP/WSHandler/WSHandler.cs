using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.Web.WebSockets;

namespace GIS_APP.WSHandler
{
    public class WSHttpHandler : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new ServiceProcessHandler { Session = context.Session });
            }
        }
        public bool IsReusable
        {
            get { return true; }
        }

    }
}
