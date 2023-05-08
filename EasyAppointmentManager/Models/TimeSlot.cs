using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a single TimeSlot
    /// </summary>
    public class TimeSlot
    {
        [Key]
        public int TimeSlotId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} is required.")]
        public DateTime? TimeSlotDate { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        // [Range(typeof(TimeSpan), "08:00", "16:00", ErrorMessage = "The {0} must be between {1} and {2}.")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        // [Range(typeof(TimeSpan), "09:00", "17:00", ErrorMessage = "The {0} must be between {1} and {2}.")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Status")]
        public TimeslotStatus TimeSlotStatus { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }

    public enum TimeslotStatus
    {
        Available,
        Booked
    }

    public class TimeSlotCreateViewModel
    {
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} is required.")]
        public DateTime? TimeSlotDate { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        // [Range(typeof(TimeSpan), "08:00", "16:00", ErrorMessage = "The {0} must be between {1} and {2}.")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        // [Range(typeof(TimeSpan), "09:00", "17:00", ErrorMessage = "The {0} must be between {1} and {2}.")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Status")]
        public TimeslotStatus TimeSlotStatus { get; set; }

        [Display(Name = "Doctors")]
        public List<Doctor>? AllAvailableDoctors { get; set; }

        public int ChosenDoctor { get; set; }
    }

    public class TimeSlotIndexViewModel
    {
        public int TimeSlotId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? TimeSlotDate { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Status")]
        public TimeslotStatus TimeSlotStatus { get; set; }

        [Display(Name = "Doctors")]
        public string DoctorName { get; set; }
    }
}
