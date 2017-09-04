using SupplierList.Business.Interface.Features.Suppliers.Commands;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Data.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
            _context.Suppliers.Remove(
                _context.Suppliers.Single(x => x.SupplierId == command.SupplierId)
                );

            _context.SaveChanges();
        }
    }
}
