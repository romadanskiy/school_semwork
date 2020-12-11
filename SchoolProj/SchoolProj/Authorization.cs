using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SchoolProj.Models;

namespace SchoolProj
{
    public static class Authorization
    {
        public static void Start(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var request = context.Request;
                if (request.Headers["new_user"]  == "true")
                {
                    SignUp(context);
                }
                else
                {
                    SignIn(context);
                }
            });
        }

        private static void SignIn(HttpContext context)
        {
            var name = context.Request.Headers["name"];
            var password = context.Request.Headers["password"];
            var user = new UsersDao().TrySignin(name, password);
            MakeResponce(context, user);
        }

        private static void SignUp(HttpContext context)
        {
            var name = context.Request.Headers["name"];
            var password = context.Request.Headers["password"];
            var user = new UsersDao().TrySignup(name, password);
            MakeResponce(context, user);
        }

        private static void MakeResponce(HttpContext context, Users user)
        {
            if (user != null)
            {
                context.Response.Headers.Add("result", "ok");
                context.Session.SetInt32("users_id", user.Id);
                context.Session.SetString("users_name", user.Name);
            }
            else
            {
                context.Response.Headers.Add("result", "failed");
            }
        }
    }
}