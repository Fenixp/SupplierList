using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Queries
{
    /// <summary>
    /// Gets supplier detail by id from db
    /// </summary>
    public class SupplierDetailQuery
    {
        /// <summary>
        /// Supplier id
        /// </summary>
        public int SupplierId { get; set; }
    }
}
