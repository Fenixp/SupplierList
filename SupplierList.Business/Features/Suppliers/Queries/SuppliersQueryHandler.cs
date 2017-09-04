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
    public class SuppliersQueryHandler : IQueryHandler<IEnumerable<SupplierModel>, SuppliersQuery>
    {
        private SupplierContext _context;

        public SuppliersQueryHandler(SupplierContext context)
        {
            _context = context;
        }

        public IEnumerable<SupplierModel> Handle(SuppliersQuery query)
        {
            return _context.Suppliers
                .Where(x => query.GroupId.HasValue ? x.Groups.Any(g => g.Group.GroupId == query.GroupId) : true)
                .Select(x => new SupplierModel
                {
                    SupplierId = x.SupplierId,
                    Address = x.Address,
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone
                });
        }
    }
}
