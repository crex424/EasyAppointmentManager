using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    public class Doctor
    {
        /// <summary>
        /// The Doctor's ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// The Doctor's legal first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// The Doctor's legal last name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// The Doctor's legal middle name (Optional) 
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The Doctor's legal date of birth
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The Doctor's specialization represented by ID
        /// </summary>
        [Required]
        public int SpecializationID { get; set; }

        /// <summary>
        /// The address of the location/building the doctors works for/in
        /// </summary>
        [Required]
        public string PlaceOfWork { get; set; }
    }
}
