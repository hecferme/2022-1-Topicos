using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.AdventureWorksLT.Model.Models
{
    public partial class CustomerAddressDTO
    {
        public string AddressType { get; set; } = null!;

        public string AddressAddressLine1 { get; set; } = null!;
        public string? AddressAddressLine2 { get; set; }
        public string AddressCity { get; set; } = null!;
        public string AddressStateProvince { get; set; } = null!;
        public string AddressCountryRegion { get; set; } = null!;
        public string AddressPostalCode { get; set; } = null!;
    }
}
