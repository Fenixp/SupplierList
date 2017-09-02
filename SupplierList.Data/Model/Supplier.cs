using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupplierList.Data.Model
{
    public class Supplier
    {
        [Key, Required]
        public int SupplierId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Address { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, Phone]
        public int Phone { get; set; }

        public List<GroupSupplierBridge> Groups { get; set; }
    }
}
