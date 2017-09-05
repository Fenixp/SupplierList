using SupplierList.Business.Interface.Features.Suppliers.Commands;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Data.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SupplierList.Business.Features.Suppliers.Commands
{
    public class DeleteSupplierCommandHandler : ICommandHandler<DeleteSupplierCommand>
    {
        private SupplierContext _context;

        public DeleteSupplierCommandHandler(SupplierContext context)
        {
            _context = context;
        }

        public void Handle(DeleteSupplierCommand command)
        {
            Supplier supplier = _context.Suppliers
                .Include(x => x.Groups)
                .Single(x => x.SupplierId == command.SupplierId);

            // Removes existing many-to-many relations between supplier and groups
            _context.GroupsSuppliersBridge.RemoveRange(supplier.Groups);
            _context.Suppliers.Remove(supplier);

            _context.SaveChanges();
        }
    }
}
