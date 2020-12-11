using System;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SchoolProj.Models;

namespace SchoolProj
{
    public static class AddComment
    {
        public static void Add(IApplicationBuilder app)
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
                var commentText = HttpUtility.UrlDecode(context.Request.Headers["comment_text"]);
                var date = DateTime.Now;
                new CommentDao().Save(new Comment(courseId, (int) userId, commentText, date));
                var userName = context.Session.GetString("users_name");
                context.Response.Headers.Add("result", "ok");
                context.Response.Headers.Add("users_name", userName);
            });
        }
    }
}