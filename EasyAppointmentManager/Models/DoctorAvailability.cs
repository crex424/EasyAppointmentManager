using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents the availability of a doctor on a given day
    /// </summary>
    public class DoctorAvailability
    {
        [Key]
        public int DoctorAvailabilityId { get; set; }

        /// <summary>
        /// The ID of the doctor
        /// </summary>
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        /// <summary>
        /// The date for which the availability is being set
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public List<Timeslot> Timeslots { get; set; }
    }

    public class Timeslot
    {
        [Key]
        public int TimeslotId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeslotStatus Status { get; set; }

        public int DoctorAvailabilityId { get; set; }
        public DoctorAvailability DoctorAvailability { get; set; }
    }

    public enum TimeslotStatus
    {
        Available,
        Booked
    }
}
