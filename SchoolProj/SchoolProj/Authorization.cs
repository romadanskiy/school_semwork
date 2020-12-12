using System.Net.Http;
using System.Text.RegularExpressions;
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

        public static void Exit(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var request = context.Request;
                if (request.Headers.ContainsKey("exit"))
                {
                    context.Response.Headers.Add("result", "ok");
                    context.Session.Remove("users_id");
                    context.Session.Remove("users_name");
                }
                else
                {
                    context.Response.Headers.Add("result", "failed");
                }
            });
        }

        private static void SignIn(HttpContext context)
        {
            var name = context.Request.Headers["name"];
            var password = context.Request.Headers["password"];
            var user = new UsersDao().TrySignin(name, password);
            MakeResponse(context, user);
        }

        private static void SignUp(HttpContext context)
        {
            var name = context.Request.Headers["name"];
            var password = context.Request.Headers["password"];
            var valid = Validate(name, password);
            if (!valid)
            {
                MakeErrorResponse(context);
                return;
            }
            var user = new UsersDao().TrySignup(name, password);
            MakeResponse(context, user);
        }

        private static bool Validate(string name, string passworsd)
        {
            var regexName = new Regex("^[a-zA-Zа-яёА-ЯЁ]{3,20}$");
            var checkName = regexName.IsMatch(name);
            
            var regexPassword = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$");
            var checkPassword = regexPassword.IsMatch(passworsd);

            return checkName && checkPassword;
        }

        private static void MakeResponse(HttpContext context, Users user)
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

        private static void MakeErrorResponse(HttpContext context)
        {
            context.Response.Headers.Add("result", "error");
        }
    }
}