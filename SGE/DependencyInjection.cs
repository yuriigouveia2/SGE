using Microsoft.Extensions.DependencyInjection;
using SGE.Repository.Classes;
using SGE.Repository.Interfaces;
using SGE.Service.Classes;
using SGE.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.WebApi
{
    public static class DependencyInjection
    {
        public static void Load(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ISchoolService, SchoolService>();
        }
    }
}
