namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a Fee
    /// </summary>
    public class Fee
    {
        
        public int FeeID { get; private set; }


        public double Price { get; set; }


        public string FeeName { get; set; }
    }
}
