using JimmInvoTest.Utility;
using System.ComponentModel.DataAnnotations;

namespace JimmInvoTest.Model
{
    public class UserLogin
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
