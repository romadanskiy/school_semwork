using System;
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
                var purchaseDao = new PurchaseDao();
                var price = int.Parse(context.Request.Headers["price"]);
                var newPurchase = new Purchase((int) userId, courseId, DateTime.Now, price);
                purchaseDao.Save(newPurchase);
                context.Response.Headers.Add("result", "ok");
            });
        }
    }
}