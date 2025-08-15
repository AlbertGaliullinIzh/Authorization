namespace Domain.Entities
{
    public record RolesDomain
    {
        public string Value { get; }

        private RolesDomain(string value)
        {
            Value = value;
        }

        public static RolesDomain Create(string value)
        {
            if (value == null) throw new ArgumentNullException("Пустое значение");

            return new RolesDomain(value);
        }
    }
}
