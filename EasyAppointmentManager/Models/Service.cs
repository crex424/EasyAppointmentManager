﻿using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a Service
    /// </summary>
    public class Service
    {
        /// <summary>
        /// The Service's unique Identity
        /// </summary>
        [Key]
        public int ServiceID { get; private set; }

        /// <summary>
        /// The Fee of the Service provided
        /// </summary>
        [Display(Name = "Fee")]
        [Required(ErrorMessage = "{0} is requried.")]
        [DataType(DataType.Currency)]
        public double Fee { get; set; }

        /// <summary>
        ///  The Service's Name
        /// </summary>
        [Display(Name = "The Service's Name")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? ServiceName { get; set; }
    }
}
