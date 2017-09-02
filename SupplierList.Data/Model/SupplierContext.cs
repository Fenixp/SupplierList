using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Data.Model
{
    public class SupplierContext : DbContext
    {
        public SupplierContext(DbContextOptions<SupplierContext> options)
            : base(options)
        {  }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupSupplierBridge> GroupsSuppliersBridge { get; set; }
        public DbSet<UpdateHistory> UpdateHistory { get; set; }

        public bool IsUpdateApplied(string version)
        {
            Version comparedVersion = new Version(version);

            // Finds out whether version already exists in the db
            return UpdateHistory.Any(x => (new Version(x.UpdateVersion)).CompareTo(comparedVersion) != -1);
        }

        public void CommitUpdate(IEnumerable<Group> groups, string version)
        {
            Groups.AddRange(groups);

            UpdateHistory.Add(new UpdateHistory
            {
                UpdateVersion = version,
                Time = DateTime.Now
            });

            SaveChanges();
        }
    }
}
