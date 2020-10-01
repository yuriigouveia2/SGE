using Newtonsoft.Json;
using SGE.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGE.DataAccess.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }

        public UserDto()
        {
        }
    }
}
