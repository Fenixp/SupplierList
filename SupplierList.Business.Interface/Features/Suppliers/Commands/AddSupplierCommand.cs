using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Commands
{
    public class AddSupplierCommand
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public IEnumerable<int> GroupIds { get; set; }
    }
}
