using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Queries
{
    /// <summary>
    /// Gets all suppliers from db
    /// </summary>
    public class SuppliersQuery
    {
        /// <summary>
        /// Filters suppliers by group. Null value gets all suppliers.
        /// </summary>
        public int? GroupId { get; set; }
    }
}
