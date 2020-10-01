using SGE.Util.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Entities
{
    public class School : BaseEntity
    {
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public string Cnpj { get; private set; }


        #region Relations
        public virtual Address Address { get; set; }
        #endregion

        public string SetCnpjIfValid(string cnpj) => CnpjUtil.IsValid(cnpj) ? RemoveSignals(cnpj) : null;
        private string RemoveSignals(string cnpj) => cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

    }
}
