using System;
using System.Web;

namespace Custom.Modules
{
    using Custom.Models;

    public class ReflectionModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //context.LogRequest += new EventHandler(OnLogRequest);

            context.BeginRequest += new EventHandler(OnBeginRequest);
        }

        #endregion

        public void OnBeginRequest(Object source, EventArgs e)
        {
            var httpApplication = (HttpApplication)source;
            var url = httpApplication.Context.Request.Url;
            var path = System.Web.Hosting.HostingEnvironment.MapPath(url.LocalPath);
            if (System.IO.File.Exists(path))
                return;
            var reflection = (RequestReflection)httpApplication.Context;

            if (reflection.IsMatch)
            {
                httpApplication.Context.RewritePath(reflection.RewritePath, true);
            }
        }

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }
    }
}
