using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Commands
{
    /// <summary>
    /// Adds a new supplier to the db
    /// </summary>
    public class AddSupplierCommand
    {
        /// <summary>
        /// Supplier name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Supplier address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Supplier email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Supplier phone
        /// </summary>
        public int Phone { get; set; }

        /// <summary>
        /// Groups the supplier belongs to
        /// </summary>
        public IEnumerable<int> GroupIds { get; set; }
    }
}
