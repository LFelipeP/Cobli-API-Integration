using CobliIntegration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobliIntegration.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICobliService CobliService { get; }
    }
}
