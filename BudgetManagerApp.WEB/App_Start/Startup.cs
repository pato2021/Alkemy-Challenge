using BudgetManagerApp.BLL.Interfaces;
using BudgetManagerApp.BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: OwinStartup(typeof(BudgetManagerApp.WEB.App_Start.Startup))]


namespace BudgetManagerApp.WEB.App_Start
{
    public class Startup
    {

        private readonly IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {


            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("BudgetManagerConnection");
        }
    }

}
