using SupplierList.Business.Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Suppliers.Commands
{
    public class DeleteSupplierCommand
    {
        public int SupplierId { get; set; }
    }
}
