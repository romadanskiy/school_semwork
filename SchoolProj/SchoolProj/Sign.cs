using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SchoolProj.Models;

namespace SchoolProj
{
    public static class Sign
    {
        public static void In(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var request = context.Request;
                SignIn(context);
            });
        }

        private static void SignIn(HttpContext context)
        {
            var name = context.Request.Headers["name"];
            var password = context.Request.Headers["password"];
            var user = new UsersDao().TrySignin(name, password);
            if (user != null)
            {
                context.Response.Headers.Add("signin_result", "ok");
                context.Session.SetInt32("users_id", user.Id);
            }
            else
            {
                context.Response.Headers.Add("signin_result", "failed");
            }
        }
    }
}