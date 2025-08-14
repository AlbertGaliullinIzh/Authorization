using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record EmailDomain
    {
        public string Value { get; }
        private EmailDomain(string value)
        {
            
            Value = value;
        }
        public static EmailDomain Create(string value) 
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email", nameof(value));
            return new EmailDomain(value);
        }
    }
}
