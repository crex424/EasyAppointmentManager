using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    public class DoctorAvailability2
    {
        [Key]
        public int DoctorAvailability2Id { get; set; }

        /// <summary>
        /// The ID of the doctor
        /// </summary>
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Timeslot Timeslot { get; set; }

        public TimeslotStatus TimeslotStatus { get; set; }
    }

    public enum TimeslotStatus
    {
        Available,
        Booked
    }

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
