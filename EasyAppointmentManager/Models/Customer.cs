using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a single Customer/Patient
    /// </summary>
    public class Customer
    {
        /// <summary> 
        /// The unique identifier for the customer
        /// </summary>
        [Key]
        public int CustomerId { get; set; }

        /// <summary>
		/// The Customer's legal first name
		/// </summary>
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string FirstName { get; set; }

        /// <summary>
        /// The Customer's legal middle name (Optional) 
        /// </summary>
        [StringLength(55)]
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        /// <summary>
		/// The Customer's legal last name
		/// </summary>
		[Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// Customer's Date of birth
        /// </summary>
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date)] // display Date picker
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The Customer's gender
        /// Female is True, of course :)
        /// Male is False
        /// Null is for Prefer not to answer
        /// </summary>
        public Boolean? Gender { get; set; }

        /// <summary>
        /// The customer's phone number
        /// </summary>
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The customer's email address
        /// </summary>
        [StringLength(100)]
        [Display(Name = "Customer's Email")]
        // [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName + " " + MiddleName; }
        }
    }
}
