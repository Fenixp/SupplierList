using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Models
{
    public class SupplierModel
    {
        /// <summary>
        /// Supplier id
        /// </summary>
        public int SupplierId { get; set; }

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
    }
}
