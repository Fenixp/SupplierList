using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SupplierList.Business.Interface.Features.Startup.Commands;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SupplierList.Business.Features.Startup.Commands
{
    public class AddGroupsFromSeedCommandHandler : ICommandHandler<AddGroupsFromSeedCommand>
    {
        SupplierContext _context;

        public AddGroupsFromSeedCommandHandler(SupplierContext context)
        {
            _context = context;
        }

        public void Handle(AddGroupsFromSeedCommand command)
        {
            DbSeedObject dbSeedObject = JsonConvert.DeserializeObject<DbSeedObject>(File.ReadAllText(command.SeedFileLocation));

            if (!_context.IsUpdateApplied(dbSeedObject.Version))
            {
                _context.CommitUpdate(dbSeedObject.Groups, dbSeedObject.Version);
            }
        }
    }
}
