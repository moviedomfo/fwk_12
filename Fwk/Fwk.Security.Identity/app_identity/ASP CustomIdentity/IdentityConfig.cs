using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using Fwk.Security.Identity;

namespace Fwk.Security.Identity
{
  

    /// <summary>
    /// 
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {


            // Send:
            return helper.SendMailAsynk(message.Subject, message.Body, String.Empty, message.Destination);
        }

        /// <summary>
        /// There are numerous email services available, but Sendgrid is a popular choice in the .NET community. 
        /// Sendgrid offers API support for multiple languages as well as an HTTP-based Web API. Additionally, Sendgrid offers direct integration with Windows Azure.
        /// 
        /// Create sendgrid accoun here: https://sendgrid.com/user/signup
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync_(IdentityMessage message)
        {
            // Credentials:
            var sendGridUserName = "yourSendGridUserName";
            var sentFrom = "whateverEmailAdressYouWant";
            var sendGridPassword = "YourSendGridPassword";

            // Configure the client:
            var client = new System.Net.Mail.SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            // Creatte the credentials:
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(sendGridUserName, sendGridPassword);

            client.EnableSsl = true;
            client.Credentials = credentials;

            // Create the message:
            var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination);

            mail.Subject = message.Subject;
            mail.Body = message.Body;

            // Send:
            return client.SendMailAsync(mail);
        }

    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

  

    //[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    //public class LoggedOrAuthorizedAttribute : AuthorizeAttribute
    //{
    //    private ApplicationDbContext ContextFactory { get; set; }
    //    public LoggedOrAuthorizedAttribute()
    //    {
    //        View = "error";
    //        Master = String.Empty;
    //    }

    //    public String View { get; set; }
    //    public String Master { get; set; }

    //    public override void OnAuthorization(System.Security.Claims.AuthorizationContext filterContext)
    //    {
    //        base.OnAuthorization(filterContext);
    //        CheckIfUserIsAuthenticated(filterContext);
    //    }

    //    private void CheckIfUserIsAuthenticated(AuthorizationContext filterContext)
    //    {
    //        var reol = Roles[0];
    //        // If Result is null, we’re OK: the user is authenticated and authorized. 
    //        if (filterContext.Result == null)
    //            return;
    //        if (AuthorizeCore(filterContext.HttpContext))
    //        {
    //            //SetCachePolicy(filterContext);
    //        }
    //        else if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
    //        {
    //            // auth failed, redirect to login page
    //            filterContext.Result = new HttpUnauthorizedResult();
    //        }
    //        //else if (filterContext.HttpContext.User.IsInRole("SuperUser") || IsOwner(new CurrentRequest(filterContext, this.RouteParameter)))
    //        //{
    //        //    //SetCachePolicy(filterContext);
    //        //}
    //        else
    //        {

    //            //returnUrl
    //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
    //            { "controller", "Account" },
    //            { "action", "Login" },
    //             { "returnUrl", filterContext.HttpContext.Request.RawUrl }
    //            });
    //            filterContext.Controller.TempData["Message"] = "No posee suficientes privilegios para esta operacion. Debe iniciar sesion para poder ver esta pagina o relaizar esta acción";


    //        }
    //        // If here, you’re getting an HTTP 401 status code. In particular,
    //        // filterContext.Result is of HttpUnauthorizedResult type. Check Ajax here. 
    //        //if (filterContext.HttpContext.User.Identity.IsAuthenticated)
    //        //{
    //        //    if (String.IsNullOrEmpty(View))
    //        //        return;
    //        //    filterContext.Result = new HttpUnauthorizedResult();

    //        //    var result = new ViewResult { ViewName = View, MasterName = Master };
    //        //    filterContext.Result = result;
    //        //}
    //    }

    //    //private bool IsOwner(CurrentRequest requestData)
    //    //{
    //    //    using (var dc = this.ContextFactory.GetDataContextWrapper())
    //    //    {
    //    //        return dc.Table<User>().Where(p => p.UserName == requestData.Username && p.UserID == requestData.OwnerID).Any();
    //    //    }
    //    //}
    //}
    //public class CurrentRequest
    //{

    //    public CurrentRequest()
    //    {
    //        this.OwnerID = -1;
    //    }

    //    public CurrentRequest(AuthorizationContext filterContext, string routeParameter)
    //        : this()
    //    {
    //        if (filterContext.RouteData.Values.ContainsKey(routeParameter))
    //        {
    //            this.OwnerID = Convert.ToInt32(filterContext.RouteData.Values[routeParameter]);
    //        }

    //        this.Username = filterContext.HttpContext.User.Identity.Name;
    //    }

    //    public CurrentRequest(HttpContextBase httpContext, string routeParameter)
    //    {
    //        if (!string.IsNullOrEmpty(routeParameter))
    //        {
    //            if (httpContext.Request.Params[routeParameter] != null)
    //            {
    //                this.OwnerID = GetOwnerID(httpContext.Request.Params[routeParameter]);
    //            }
    //            else if (string.Equals("id", routeParameter, StringComparison.OrdinalIgnoreCase))
    //            {
    //                // id may be last element in path if not included as a parameter
    //                this.OwnerID = GetOwnerID(httpContext.Request.Path.Split('/').Last());
    //            }
    //        }

    //        this.Username = httpContext.User.Identity.Name;
    //    }

    //    private int GetOwnerID(string id)
    //    {
    //        int ownerID;
    //        if (!int.TryParse(id, out ownerID))
    //        {
    //            ownerID = -1;
    //        }
    //        return ownerID;
    //    }

    //    public int OwnerID { get; set; }
    //    public string Username { get; set; }
    //}
}
