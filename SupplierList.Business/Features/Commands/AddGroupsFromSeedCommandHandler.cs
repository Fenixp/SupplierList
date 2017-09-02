using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SupplierList.Business.Interface.Features.Commands;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SupplierList.Business.Features.Commands
{
    public class AddGroupsFromSeedCommandHandler : ICommandHandler<AddGroupsFromSeedCommand>
    {
        SupplierContext _context;

        AddGroupsFromSeedCommandHandler(SupplierContext context)
        {
            _context = context;
        }

        public void Handle(AddGroupsFromSeedCommand command)
        {
            DbSeedObject dbSeedObject = JsonConvert.DeserializeObject<DbSeedObject>(File.ReadAllText(command.SeedFileLocation));

            if (!_context.IsUpdateApplied(dbSeedObject.Version))
            {
                _context.Groups.AddRange(dbSeedObject.Groups);
            }
        }
    }
}
