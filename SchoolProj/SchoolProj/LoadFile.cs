using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SchoolProj.Models;
using File = System.IO.File;

namespace SchoolProj
{
    public static class LoadFile
    {
        public static void Load(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var usersId = context.Session.GetInt32("users_id");
                var file = context.Request.Form.Files.GetFile("file");
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var fileExtension = Path.GetExtension(file.FileName);
                
                var newFile = new Models.File((int) usersId, fileName, fileExtension);
                var fileDao = new FileDao();
                fileDao.Save(newFile);
                
                await using (var fileStream = File.Open($"wwwroot\\files\\{file.FileName}", FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            });
        }
    }
}