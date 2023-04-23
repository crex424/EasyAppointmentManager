using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Range from 0 to 23
        /// Timeslot of the appointment
        /// Assume each visit is 1 hour
        /// 8 represents 8:00AM - 9:00AM
        /// </summary>
        [Range(8, 16, ErrorMessage = "{0} should be from 8:00 to 16:00.")]
        [Display(Name = "Time")]
        [Required(ErrorMessage = "{0} is required.")]
        public Timeslot Timeslot { get; set; }

        [Display(Name = "Timeslot Status")]
        [Required(ErrorMessage = "{0} is required.")]
        public bool TimeslotStatus { get; set; }

        [Display(Name = "Appointment Status")]
        [Required(ErrorMessage = "{0} is required.")]
        public AppointmentStatus AppointmentStatus { get; set; }

        public Customer? Customer { get; set; }

        public Clinic? Clinic { get; set; }

        public Service? Service { get; set; }

        public Doctor? Doctor { get; set; }
    }

    public class AppointmentCreateViewModel
    {
        /// <summary>
        /// Date of the appointment
        /// </summary>
        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date)] // display Date picker
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Range from 0 to 23
        /// Timeslot of the appointment
        /// Assume each visit is 1 hour
        /// 8 represents 8:00AM - 9:00AM
        /// </summary>
        [Range(8, 16, ErrorMessage = "{0} should be from 8:00 to 16:00.")]
        [Display(Name = "Time")]
        [Required(ErrorMessage = "{0} is required.")]
        public Timeslot Timeslot { get; set; }

        //public Timeslot ChosenTimeslot { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "{0} is required.")]
        public bool TimeslotStatus { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "{0} is required.")]
        public AppointmentStatus AppointmentStatus { get; set; }

        [Display(Name = "Customer")]
        public List<Customer>? AllAvailableCustomers { get; set; }

        public int ChosenCustomer { get; set; }

        [Display(Name = "Clinic")]
        public List<Clinic>? AllAvailableClinics { get; set; }

        public int? ChosenClinic { get; set; }

        [Display(Name = "Service")]
        public List<Service>? AllAvailableServicesByClinicId { get; set; }

        public int? ChosenService { get; set; }

        [Display(Name = "Doctor")]
        public List<Doctor>? AllAvailableDoctorsByServiceId { get; set; }

        public int? ChosenDoctor { get; set; }
    }

    public enum AppointmentStatus
    {
        None, 
        Confirmed,
        Cancelled,
        Missed,
        Rescheduled
    }
    /*
    public enum Timeslot
    {
        /*
        [Display(Name = "12:00AM - 1:00AM")]
        Slot0 = 0,
        [Display(Name = "1:00AM - 2:00AM")]
        Slot1 = 1,
        [Display(Name = "2:00AM - 3:00AM")]
        Slot2 = 2,
        [Display(Name = "3:00AM - 4:00AM")]
        Slot3 = 3,
        [Display(Name = "4:00AM - 5:00AM")]
        Slot4 = 4,
        [Display(Name = "5:00AM - 6:00AM")]
        Slot5 = 5,
        [Display(Name = "6:00AM - 7:00AM")]
        Slot6 = 6,
        [Display(Name = "7:00AM - 8:00AM")]
        Slot7 = 7,
        */
        
        /*
        [Display(Name = "8:00AM - 9:00AM")]
        Slot8 = 8,
        [Display(Name = "9:00AM - 10:00AM")]
        Slot9 = 9,
        [Display(Name = "10:00AM - 11:00AM")]
        Slot10 = 10,
        [Display(Name = "11:00AM - 12:00PM")]
        Slot11 = 11,
        [Display(Name = "12:00PM - 1:00PM")]
        Slot12 = 12,
        [Display(Name = "1:00PM - 2:00PM")]
        Slot13 = 13,
        [Display(Name = "2:00PM - 3:00PM")]
        Slot14 = 14,
        [Display(Name = "3:00PM - 4:00PM")]
        Slot15 = 15,
        [Display(Name = "4:00PM - 5:00PM")]
        Slot16 = 16 
        */
        
        /*,
        [Display(Name = "5:00PM - 6:00PM")]
        Slot17 = 17,
        [Display(Name = "6:00PM - 7:00PM")]
        Slot18 = 18,
        [Display(Name = "7:00PM - 8:00PM")]
        Slot19 = 19,
        [Display(Name = "8:00PM - 9:00PM")]
        Slot20 = 20,
        [Display(Name = "9:00PM - 10:00PM")]
        Slot21 = 21,
        [Display(Name = "10:00PM - 11:00PM")]
        Slot22 = 22,
        [Display(Name = "11:00PM - 12:00AM")]
        Slot23 = 23*/

}
