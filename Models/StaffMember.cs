using System.ComponentModel.DataAnnotations;

namespace StaffManagementApp.Models
{
    public class StaffMember
    {
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Position is required.")]
        [StringLength(100)]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(100)]
        public string Unit { get; set; } = string.Empty;
    }
}
