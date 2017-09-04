using SupplierList.Business.Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Commands
{
    /// <summary>
    /// Deletes a supplier from the db
    /// </summary>
    public class DeleteSupplierCommand
    {
        /// <summary>
        /// Id of the supplier to be deleted
        /// </summary>
        public int SupplierId { get; set; }
    }
}
