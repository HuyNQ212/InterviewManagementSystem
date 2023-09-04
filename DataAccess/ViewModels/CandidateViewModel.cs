using DataAccess.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.ViewModels
{
    public class CandidateViewModel
    {
        public int Id { get; set; }

        [DisplayName("Full name")]
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? Address { get; set; }

        public string? Gender { get; set; }

        [DisplayName("Year of experiences")]
        [Range(0, 20)]
        public int? YearOfExperience { get; set; }

        public string? Note { get; set; }

        public int? RecruiterId { get; set; }

        public virtual User? Recruiter { get; set; }

        public int? StatusId { get; set; }

        public virtual CandidateStatus? Status { get; set; }
    }
}
