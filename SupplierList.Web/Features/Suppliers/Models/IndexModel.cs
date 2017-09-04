using SupplierList.Business.Interface.Features.Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierList.Web.Features.Suppliers.Models
{
    public class IndexModel
    {
        public IEnumerable<SupplierModel> Suppliers { get; set; }
    }
}
