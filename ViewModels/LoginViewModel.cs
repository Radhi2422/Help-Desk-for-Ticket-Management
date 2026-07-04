
using System.ComponentModel.DataAnnotations;

namespace Help_Desk_for_Ticket_Management_System.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}