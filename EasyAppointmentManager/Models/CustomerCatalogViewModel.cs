namespace EasyAppointmentManager.Models
{
    public class CustomerCatalogViewModel
    {
        public CustomerCatalogViewModel(List<Customer> customers, int lastPage, int currPage)
        {
            Customers = customers;
            LastPage = lastPage;
            CurrentPage = currPage;
        }

        public List<Customer> Customers { get; private set; }

        /// <summary>
        /// The last page of catalog.
        /// Calculated by total number of customers per page
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// The current page the user is viewing
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}
