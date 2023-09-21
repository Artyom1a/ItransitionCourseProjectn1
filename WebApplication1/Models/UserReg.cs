namespace WebApplication1.Models
{
    public class UserReg
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public int Roles { get; set; }

        public bool IsSelected { get; set; }
    }
}
