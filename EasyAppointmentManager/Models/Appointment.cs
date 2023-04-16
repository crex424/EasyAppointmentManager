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

        public DateTime Date { get; set; }

        public int Timeslot { get; set; }

        public bool IsAvailable { get; set; }


    }
}
