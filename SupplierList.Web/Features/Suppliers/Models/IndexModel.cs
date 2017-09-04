using Microsoft.AspNetCore.Mvc.Rendering;
using SupplierList.Business.Interface.Features.Suppliers.Models;
using SupplierList.Web.Features.Suppliers.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierList.Web.Features.Suppliers.Models
{
    public class IndexModel
    {
        public IEnumerable<SupplierModel> Suppliers { get; set; }
        public IEnumerable<SelectListItem> Groups { get; set; }

        [Display(Name = nameof(SupplierFormRX.GroupFilter), ResourceType = typeof(SupplierFormRX))]
        public int? SelectedGroupId { get; set; }
    }
}
