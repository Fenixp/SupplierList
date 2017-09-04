using SupplierList.Business.Interface.Features.Suppliers.Commands;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Data.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Features.Suppliers.Commands
{
    public class AddSupplierCommandHandler : ICommandHandler<AddSupplierCommand>
    {
        private SupplierContext _context;

        public AddSupplierCommandHandler(SupplierContext context)
        {
            _context = context;
        }

        public void Handle(AddSupplierCommand command)
        {
            List<GroupSupplierBridge> supplierGroups = new List<GroupSupplierBridge>();

            if (command.GroupIds != null)
            foreach (int groupId in command.GroupIds)
            {
                Group group = _context.Groups.Single(x => x.GroupId == groupId);

                supplierGroups.Add(new GroupSupplierBridge
                {
                    Group = group
                });
            }

            Supplier supplier = new Supplier
            {
                Address = command.Address,
                Email = command.Email,
                Name = command.Name,
                Phone = command.Phone,
                Groups = supplierGroups
            };

            _context.Suppliers.Add(supplier);

            _context.SaveChanges();
        }
    }
}
