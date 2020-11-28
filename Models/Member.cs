using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group22_ParkingApp.Models
{
    public class Member
    {
        public int Id { get; set; }

        // staff user ID from AspNetUser table
        public string StaffId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name = "License Plate Number")]
        public string LicenseNo { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public MemberStatus Status { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<ParkingSpot> ParkingSpots { get; set; }
    }

    public enum MemberStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
