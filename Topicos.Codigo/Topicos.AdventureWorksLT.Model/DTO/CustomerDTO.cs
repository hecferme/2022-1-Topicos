using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.AdventureWorksLT.Model.Models
{
    public partial class CustomerDTO
    {
        public CustomerDTO()
        {
            CustomerAddresses = new HashSet<CustomerAddressDTO>();
        }

        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? CompanyName { get; set; }
        public string? SalesPerson { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public virtual ICollection<CustomerAddressDTO> CustomerAddresses { get; set; }
    }
}
