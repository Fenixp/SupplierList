using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Infrastructure
{
    public interface IQueryHandler<Treturn, Tquery>
    {
        Treturn Handle(Tquery query);
    }
}
