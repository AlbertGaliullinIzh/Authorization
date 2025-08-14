using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record NameDomain
    {
        public string Value { get; }

        private NameDomain(string value) 
        {
            Value = value;
        }

        public static NameDomain Create(string value)
        {
            if (value == null) throw new ArgumentNullException("Пустое имя");

            return new NameDomain(value);
        }
    }
}
