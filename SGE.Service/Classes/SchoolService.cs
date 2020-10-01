using SGE.DataAccess.Entities;
using SGE.Repository.Interfaces;
using SGE.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Service.Classes
{
    public class SchoolService : ISchoolService
    {
        private IRepository<School> _schoolRepository;
        public SchoolService(IRepository<School> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public IEnumerable<School> FilterSchool(string name)
        {
            return _schoolRepository.Filter(prop => prop.Name.Equals(name));
        }

        public School GetSchool(Guid id) => _schoolRepository.Get(id);

        public IEnumerable<School> GetSchools() => _schoolRepository.GetAll();
    }
}
