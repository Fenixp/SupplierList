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
    public class GroupsQueryHandler : IQueryHandler<IEnumerable<GroupModel>, GroupsQuery>
    {
        private SupplierContext _context;

        public GroupsQueryHandler(SupplierContext context)
        {
            _context = context;
        }

        public IEnumerable<GroupModel> Handle(GroupsQuery query)
        {
            return _context.Groups.Select(x => new GroupModel
            {
                GroupId = x.GroupId,
                Name = x.Name
            });
        }
    }
}
