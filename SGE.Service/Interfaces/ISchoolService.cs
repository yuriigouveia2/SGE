using SGE.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Service.Interfaces
{
    public interface ISchoolService
    {
        IEnumerable<School> GetSchools();
        School GetSchool(Guid id);
        IEnumerable<School> FilterSchool(string name);
    }
}
