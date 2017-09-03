using SupplierList.Business.Interface.Features.Suppliers.Commands;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Data.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Features.Suppliers.Commands
{
    public class EditSupplierCommandHandler : ICommandHandler<EditSupplierCommand>
    {
        private SupplierContext _context;

        public EditSupplierCommandHandler(SupplierContext context)
        {
            _context = context;
        }

        public void Handle(EditSupplierCommand command)
        {
            Supplier supplier = _context.Suppliers.Single(x => x.SupplierId == command.SupplierId);

            _context.GroupsSuppliersBridge.RemoveRange(
                _context.GroupsSuppliersBridge.Where(x => command.GroupIds.Contains(x.GroupSupplierBridgeId))
                );

            List<GroupSupplierBridge> supplierGroups = new List<GroupSupplierBridge>();

            foreach (int groupId in command.GroupIds)
            {
                Group group = _context.Groups.Single(x => x.GroupId == groupId);

                supplierGroups.Add(new GroupSupplierBridge
                {
                    Group = group
                });
            }

            supplier.Address = command.Address;
            supplier.Email = command.Email;
            supplier.Name = command.Name;
            supplier.Phone = command.Phone;
            supplier.Groups = supplierGroups;
        }
    }
}
