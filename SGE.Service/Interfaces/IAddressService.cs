using SGE.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Service.Interfaces
{
    public interface IAddressService
    {
        Address GetAddress(Guid id);
    }
}
