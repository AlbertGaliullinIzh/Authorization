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
