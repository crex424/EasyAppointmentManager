using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a single Appointment of a Customer
    /// </summary>
    public class CustomerAppointment
    {
        /// <summary> 
        /// The unique identifier for the CustomerAppointment
        /// </summary>
        [Key]
        public int CustomerAppointmentId { get; set; }

        public int TimeSlotId { get; set; }

        public TimeSlot? TimeSlot { get; set; }

        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public CustomerAppointmentStatus CustomerAppointmentStatus { get; set;}

    }

    public enum CustomerAppointmentStatus
    {
        None,
        Booked,
        Confirmed,
        Cancelled,
        Missed,
        Rescheduled
    }

    /// <summary>
    /// Represents a single Appointment of a Customer
    /// </summary>
    public class CustomerAppointmentCreateViewModel
    {
        [Display(Name = "Customer")]
        public List<Customer>? AllAvailableCustomers { get; set; }

        [Display(Name = "Customer")]
        public int? ChosenCustomerId { get; set; }

        [Display(Name = "Doctor")]
        public List<Doctor>? AllAvailableDoctors { get; set; }

        [Display(Name = "Doctor")]
        public int? ChosenDoctorId { get; set; }

        public Doctor? ChosenDoctor { get; set; }

        [Display(Name = $"Availabilities of selected doctor")]
        public List<TimeSlot>? AvailableTimeSlotsByDoctorId { get; set; }

        [Display(Name = "Date")]
        public int? ChosenTimeSlotId { get; set; }
        
        /*
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        */

        public CustomerAppointmentStatus CustomerAppointmentStatus { get; set; }

    }
}
