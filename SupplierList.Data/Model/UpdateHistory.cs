using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupplierList.Data.Model
{
    public class UpdateHistory
    {
        [Key, Required]
        public string UpdateVersion { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
