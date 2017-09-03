using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Models
{
    public class SupplierModel
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public IEnumerable<string> GroupNames { get; set; }
    }
}
