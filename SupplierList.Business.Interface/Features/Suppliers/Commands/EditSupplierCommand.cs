using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Commands
{
    /// <summary>
    /// Edits supplier in db
    /// </summary>
    public class EditSupplierCommand
    {
        /// <summary>
        /// Id of the supplier to edit
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Name of the supplier
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
