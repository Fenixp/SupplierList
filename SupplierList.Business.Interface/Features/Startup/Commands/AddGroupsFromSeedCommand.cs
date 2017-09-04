using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Features.Startup.Commands
{
    /// <summary>
    /// Checks current version of db groups and if it's older than the seed file, adds new groups
    /// </summary>
    public class AddGroupsFromSeedCommand
    {
        /// <summary>
        /// Location of the group seed file
        /// </summary>
        public string SeedFileLocation { get; set; }
    }
}
