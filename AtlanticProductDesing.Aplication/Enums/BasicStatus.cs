namespace AtlanticProductDesing.Application.Enums
{
    public class BasicStatus
    {
        public static BasicStatus Inactive { get; } = new BasicStatus(0, "inactivo");
        public static BasicStatus Active { get; } = new BasicStatus(1, "activo");

        public string Name { get; private set; }
        public int Value { get; private set; }

        private BasicStatus(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public static IEnumerable<BasicStatus> List()
        {
            return new[] { Inactive, Active };
        }

        public static BasicStatus FromString(string name) => List().SingleOrDefault(r => string.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));

        public static BasicStatus FromValue(int value) => List().SingleOrDefault(r => r.Value == value);
    }
}
