using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EasyAppointmentManager.Models.Appointment;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents the availability of a doctor on a given day
    /// </summary>
    public class DoctorAvailability
    {
        /// <summary>
        /// The ID of the doctor
        /// </summary>
        [Key]
        public int DoctorId { get; set; }

        /// <summary>
        /// The date for which the availability is being set
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// The list of available timeslots for the day
        /// </summary>
        public List<TimeSpan> AvailableTimeslots { get; set; }

        /// <summary>
        /// The status of each timeslot (Available/Booked)
        /// </summary>
        public List<TimeslotStatus> TimeslotStatuses { get; set; }
    }

    public enum TimeslotStatus
    {
        Available,
        Booked
    }
}
