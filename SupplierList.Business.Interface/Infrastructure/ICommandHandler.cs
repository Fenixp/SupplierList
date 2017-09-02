using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierList.Business.Interface.Infrastructure
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
