using EasyAppointmentManager.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a single TimeSlot
    /// </summary>
    public class TimeSlot
    {
        /// <summary>
        /// The unique identifier for the TimeSlot
        /// </summary>
        [Key]
        public int TimeSlotId { get; set; }

        /// <summary>
        /// The TimeSlot's date
        /// </summary>
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} is required.")]
        public DateTime? TimeSlotDate { get; set; }

        /// <summary>
        /// Start time of the TimeSlot
        /// </summary>
        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        // [Range(typeof(TimeSpan), "08:00", "16:00", ErrorMessage = "The {0} must be between {1} and {2}.")]
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// End time of the TimeSlot
        /// </summary>
        [Display(Name = "End Time")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        // [Range(typeof(TimeSpan), "09:00", "17:00", ErrorMessage = "The {0} must be between {1} and {2}.")]
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// The status of the TimeSlot
        /// </summary>
        [Display(Name = "Status")]
        public TimeslotStatus TimeSlotStatus { get; set; }

        /// <summary>
        /// Foreign Key - DoctorId of the doctor asscociated with the TimeSlot
        /// </summary>
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }

    /// <summary>
    /// The status of the TimeSlot
    /// </summary>
    public enum TimeslotStatus
    {
        Available,
        Booked
    }

    /// <summary>
    /// Represents a single TimeSlot for the Create view
    /// </summary>
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
        public List<Doctor>? Doctors { get; set; }

        public int ChosenDoctor { get; set; }
    }

    /// <summary>
    /// Represents a single TimeSlot for the Index/Details/Edit/Delete views
    /// </summary>
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
        public string? DoctorName { get; set; }

    }

    // 1. Create a database seed method in application. This method will be responsible for adding initial data to the database.
    /// <summary>
    /// Populate database with TimeSlot records with the TimeSlotStatus set to "Available" in ASP.NET
    /// For testing purpose only
    /// </summary>
    public static class DatabaseSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (context.TimeSlot.Any())
            {
                return; // Database already seeded, no action needed
            }

            var doctors = context.Doctor.ToList();

            var timeSlots = new List<TimeSlot>();

            var startTime = new TimeSpan(8, 0, 0); // Start time: 8:00 AM
            var endTime = new TimeSpan(16, 0, 0); // End time: 4:00 PM

            var currentTime = startTime;

            while (currentTime < endTime)
            {
                foreach (var doctor in doctors)
                {
                    var timeSlot = new TimeSlot
                    {
                        TimeSlotDate = DateTime.Now.Date, // Set the date as desired
                        StartTime = currentTime,
                        EndTime = currentTime.Add(new TimeSpan(1, 0, 0)), // Set the duration to one hour
                        TimeSlotStatus = TimeslotStatus.Available,
                        DoctorId = doctor.DoctorId
                    };

                    timeSlots.Add(timeSlot);
                }

                currentTime = currentTime.Add(new TimeSpan(1, 0, 0)); // Increment current time by one hour
            }

            context.TimeSlot.AddRange(timeSlots);
            context.SaveChanges();
        }
        // Also add below code to Program.cs
        /* 
        // Create a scope to resolve the database context and call the seed method
        using (var scope = serviceProvider.ServiceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DatabaseSeeder.SeedData(dbContext);
        }
        */
    }
}
