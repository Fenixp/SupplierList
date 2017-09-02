using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupplierList.Data.Model
{
    public class Group
    {
        [Key, Required]
        public int GroupId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public List<GroupSupplierBridge> Suppliers { get; set; }
    }
}
