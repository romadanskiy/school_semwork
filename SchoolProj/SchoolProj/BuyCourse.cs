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
                    if (context.Request.Cookies.ContainsKey("users_id"))
                    {
                        userId = int.Parse(context.Request.Cookies["users_id"]);
                        var usersName = context.Request.Cookies["users_name"];
                        context.Session.SetInt32("users_id", (int) userId);
                        context.Session.SetString("users_name", usersName);
                    }
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