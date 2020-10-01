using SGE.DataAccess.Entities;
using SGE.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Builders
{
    public class UserBuilder
    {
        private List<Action<User>> Actions;
        public UserBuilder()
        {
            Actions = new List<Action<User>>();
        }

        public void AddAction(Action<User> action)
        {
            Actions.Add(action);
        }

        public UserBuilder AddName(string name)
        {
            AddAction(usr => { usr.Name = name; });
            return this;
        }

        public UserBuilder AddSurname(string surname)
        {
            AddAction(usr => { usr.Surname = surname; });
            return this;
        }

        public UserBuilder AddCpf(Cpf cpf)
        {
            AddAction(usr => { usr.Cpf = cpf.ToString(); });
            return this;
        }

        public UserBuilder AddEmail(Email email)
        {
            AddAction(usr => { usr.Email = email.ToString(); });
            return this;
        }

        public UserBuilder AddAddressReference(Guid addressId)
        {
            AddAction(usr => { usr.AddressId = addressId; });
            return this;
        }

        public User Build()
        {
            var user = new User();
            Actions.ForEach(action => action(user));
            return user;
        }


    }
}
