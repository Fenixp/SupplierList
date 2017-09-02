using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupplierList.Data.Model
{
    // EFCore currently doesn't support many to many relationships
    public class GroupSupplierBridge
    {
        [Key]
        public int GroupSupplierBridgeId { get; set; }

        [Required]
        public Group Group { get; set; }

        [Required]
        public Supplier Supplier { get; set; }
    }
}
