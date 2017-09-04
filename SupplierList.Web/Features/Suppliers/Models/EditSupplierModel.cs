using Microsoft.AspNetCore.Mvc.Rendering;
using SupplierList.Business.Interface.Features.Suppliers.Models;
using SupplierList.Web.Features.Suppliers.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupplierList.Web.Features.Suppliers.Models
{
    public class EditSupplierModel
    {
        public int SupplierId { get; set; }

        [Required, Display(Name = nameof(SupplierFormRX.Name), ResourceType = typeof(SupplierFormRX))]
        public string Name { get; set; }

        [Required, Display(Name = nameof(SupplierFormRX.Address), ResourceType = typeof(SupplierFormRX))]
        public string Address { get; set; }

        [Required, EmailAddress, Display(Name = nameof(SupplierFormRX.Email), ResourceType = typeof(SupplierFormRX))]
        public string Email { get; set; }

        [Required, Phone, Display(Name = nameof(SupplierFormRX.Phone), ResourceType = typeof(SupplierFormRX))]
        public int Phone { get; set; }

        public IEnumerable<SelectListItem> Groups { get; set; }

        [Required, Display(Name = nameof(SupplierFormRX.Groups), ResourceType = typeof(SupplierFormRX))]
        public IEnumerable<int> SelectedGroups { get; set; }
    }
}
