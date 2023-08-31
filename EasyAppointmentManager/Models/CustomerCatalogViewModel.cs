namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// A pagenation helper class
    /// </summary>
    public class CustomerCatalogViewModel
    {
        /// <summary>
        /// Constructor method for CustomerCatalog
        /// </summary>
        /// <param name="customers">A list of customers</param>
        /// <param name="lastPage">The last page of the catalog</param>
        /// <param name="currPage">The current page the user is viewing</param>
        public CustomerCatalogViewModel(List<Customer> customers, int lastPage, int currPage)
        {
            Customers = customers;
            LastPage = lastPage;
            CurrentPage = currPage;
        }
        /// <summary>
        /// List of customers to be shown in the catalog
        /// </summary>
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
