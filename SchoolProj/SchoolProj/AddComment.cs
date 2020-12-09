using System;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Builder;
using SchoolProj.Models;

namespace SchoolProj
{
    public static class AddComment
    {
        public static void Add(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                // var userid = context.Session.GetInt32("user_id");
                var courseId = int.Parse(context.Request.Headers["course_id"]);
                var commentText = HttpUtility.UrlDecode(context.Request.Headers["comment_text"]);
                var date = DateTime.Now;
                new CommentDao().Save(new Comment(courseId, 1, commentText, date));
            });
        }
    }
}