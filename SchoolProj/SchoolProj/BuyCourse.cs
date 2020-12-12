using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SchoolProj.Models;

namespace SchoolProj
{
    public static class BuyCourse
    {
        public static void Buy(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var userId = context.Session.GetInt32("users_id");
                if (userId == null)
                {
                    context.Response.Headers.Add("result", "error");
                    return;
                }
                var courseId = int.Parse(context.Request.Headers["course_id"]);
                var usersDao = new UsersDao();
                usersDao.AddCourseToUser((int) userId, courseId);
                context.Response.Headers.Add("result", "ok");
            });
        }
    }
}