using Authorization.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record LoginDomain
    {
        public string Value { get; }
        private LoginDomain(string value) 
        {
            Value = value;
        }
        public static LoginDomain Create(string value)
        {
            if (value == null) throw new ArgumentNullException("Пустой логин");
            return new LoginDomain(value);
        }
    }
}
