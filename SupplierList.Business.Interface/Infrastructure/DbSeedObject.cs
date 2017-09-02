using SupplierList.Data.Model;

namespace SupplierList.Business.Interface.Infrastructure
{
    public class DbSeedObject
    {
        public string Version { get; set; }
        public Group[] Groups { get; set; }
    }
}
