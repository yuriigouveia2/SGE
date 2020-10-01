using SGE.DataAccess.Entities;
using SGE.Repository.Interfaces;
using SGE.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Service.Classes
{
    public class AddressService : IAddressService
    {
        private IRepository<Address> _addressRepository;

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address GetAddress(Guid id) => _addressRepository.Get(id); 
    }
}
