using SupplierList.Business.Interface.Features.Suppliers.Models;
using SupplierList.Business.Interface.Features.Suppliers.Queries;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Data.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Features.Suppliers.Queries
{
    public class SupplierDetailQueryHandler : IQueryHandler<SupplierDetailModel, SupplierDetailQuery>
    {
        SupplierContext _context;

        public SupplierDetailQueryHandler(SupplierContext context)
        {
            _context = context;
        }

        public SupplierDetailModel Handle(SupplierDetailQuery query)
        {
            return _context.Suppliers.Where(x => x.SupplierId == query.SupplierId)
                .Select(x => new SupplierDetailModel
                {
                    Address = x.Address,
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                    SupplierId = x.SupplierId,
                    Groups = x.Groups.Select(g => new GroupModel
                    {
                        GroupId = g.Group.GroupId,
                        Name = g.Group.Name
                    })
                })
                .Single();
        }
    }
}
