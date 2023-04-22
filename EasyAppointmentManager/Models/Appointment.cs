using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a single Appointment
    /// </summary>
    public class Appointment
    {
        /// <summary> 
        /// The unique identifier for the appointment
        /// </summary>
        [Key]
        public int AppointmentId { get; set; }

        /// <summary>
        /// Date of the appointment
        /// </summary>
        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date)] // display Date picker
        public DateTime Date { get; set; }

        /// <summary>
        /// Timeslot of the appointment
        /// Assume each visit is 1 hour
        /// Every work day has 8 business hours divided into 8 timeslots
        /// </summary>
        public int Timeslot { get; set; }

        public bool TimeslotStatus { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public Customer Customer { get; set; }

        public Clinic Clinic { get; set; }

        public Service Service { get; set; }

        public Doctor Doctor { get; set; }


    }

    public class AppointmentCreateViewModel
    {
        /// <summary>
        /// Date of the appointment
        /// </summary>
        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date)] // display Date picker
        public DateTime Date { get; set; }

        /// <summary>
        /// Range from 0 to 23
        /// Timeslot of the appointment
        /// Assume each visit is 1 hour
        /// 8 represents 8:00AM - 9:00AM
        /// </summary>
        [Range(0, 23)]
        public int Timeslot { get; set; }

        public bool TimeslotStatus { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public List<Customer> AllAvailableCustomers { get; set; }

        public List<Clinic> AllAvailableClinics { get; set; }

        public List<Service> AllAvailableServices { get; set; }

        public List<Doctor> AllAvailableDoctors { get; set; }
    }

    public enum AppointmentStatus
    {
        None, 
        Confirmed,
        Cancelled,
        Missed,
        Rescheduled
    }
}
