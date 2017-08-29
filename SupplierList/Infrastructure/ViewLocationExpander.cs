using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

namespace SupplierList.Infrastructure
{
    /* 
     * LocationExpander for view locations 
     * See https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/
     */
    public class FeatureLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return new string[] { "/Features/{1}/Views/{0}.cshtml", "/Features/Shared/Views/{0}.cshtml" };
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Not necessary
        }
    }
}
