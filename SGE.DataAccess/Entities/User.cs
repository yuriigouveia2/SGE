using SGE.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Guid AddressId { get; set; }

        #region Relashionship
        public virtual Address Address { get; set; }
        #endregion
    }
}
