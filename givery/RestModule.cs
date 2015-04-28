using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace givery
{
    public class RestModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += delegate
            {
                HttpContext ctx = HttpContext.Current;
                string path = ctx.Request.AppRelativeCurrentExecutionFilePath;

                int i = path.IndexOf('/', 2);
                if (i > 0)
                {
                    string svc = path.Substring(0, i) + ".svc";
                    string rest = path.Substring(i, path.Length - i);
                    ctx.RewritePath(svc, rest, ctx.Request.QueryString.ToString(), false);
                }
            };
        }
    }
}