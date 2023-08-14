﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

    /// <summary>
    /// Represents a single Appointment of a Customer
    /// </summary>
    public class CustomerAppointmentCreateViewModel
    {
        [Display(Name = "Customer")]
        public List<Customer>? AllAvailableCustomers { get; set; }

        public int ChosenCustomerId { get; set; }

        [Display(Name = "Doctors")]
        public List<Doctor>? AllAvailableDoctors { get; set; }

        public int ChosenDoctorId { get; set; }

        public List<TimeSlot>? TimeSlotsByDoctorId { get; set; }

        //This property will be used to populate employee dropdownlist  
        public IEnumerable<SelectListItem> TimeSlotsByDoctorIdListItems
        {
            get
            {
                return new SelectList(TimeSlotsByDoctorId, "TimeSlot Date", "TimeSlot Start Time");
            }
        }

        public int? ChosenTimeSlotId { get; set; }
        /*
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        */

        public CustomerAppointmentStatus CustomerAppointmentStatus { get; set; }

    }
}