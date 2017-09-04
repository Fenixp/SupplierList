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
    public class EditSupplierCommandHandler : ICommandHandler<EditSupplierCommand>
    {
        private SupplierContext _context;

        public EditSupplierCommandHandler(SupplierContext context)
        {
            _context = context;
        }

        public void Handle(EditSupplierCommand command)
        {
            Supplier supplier = _context.Suppliers
                .Include(x => x.Groups)
                .Single(x => x.SupplierId == command.SupplierId);

            // Removes existing many-to-many relations between supplier and groups
            _context.GroupsSuppliersBridge.RemoveRange(supplier.Groups);

            List<GroupSupplierBridge> supplierGroups = new List<GroupSupplierBridge>();

            // Creates new many-to-many relations between supplier and groups. Unify within entity?
            if (command.GroupIds != null)
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

            _context.SaveChanges();
        }
    }
}
