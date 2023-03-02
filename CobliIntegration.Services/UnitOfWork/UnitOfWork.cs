using CobliIntegration.Domain.Configuration;
using CobliIntegration.Services.Interfaces;
using CobliIntegration.Services.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobliIntegration.Services.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork       
    {
        private readonly CobliOptions cobliSecret;

        public UnitOfWork(IOptions<CobliOptions> cobliSecret) 
        {
            this.cobliSecret = cobliSecret.Value;
        } 


        private ICobliService cobliService;

        public ICobliService CobliService 
        {
            get
            {
                return cobliService ??= new CobliService(cobliSecret.api_url, cobliSecret.api_key);
            }
        }
    }
}
