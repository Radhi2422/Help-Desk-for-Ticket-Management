using System.ComponentModel.DataAnnotations;

namespace Help_Desk_for_Ticket_Management_System.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}