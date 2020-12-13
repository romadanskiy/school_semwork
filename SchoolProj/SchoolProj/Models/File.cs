namespace SchoolProj.Models
{
    public class File : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }

        public File(int id, int userId, string fileName, string fileExtension)
        {
            Id = id;
            UserId = userId;
            FileName = fileName;
            FileExtension = fileExtension;
        }
        
        public File(int userId, string fileName, string fileExtension)
        {
            UserId = userId;
            FileName = fileName;
            FileExtension = fileExtension;
        }
    }
}