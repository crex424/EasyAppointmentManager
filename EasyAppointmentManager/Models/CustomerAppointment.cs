﻿using System.ComponentModel.DataAnnotations;
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

        public CustomerAppointmentStatus CustomerAppointmentStatus { get; set;}

    }

    public enum CustomerAppointmentStatus
    {
        None,
        Confirmed,
        Cancelled,
        Missed,
        Rescheduled
    }
}
