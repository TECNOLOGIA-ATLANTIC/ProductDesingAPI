namespace AtlanticProductDesing.Application.Enums
{
    public class TransactionStatus
    {
        public static TransactionStatus Sending { get; } = new TransactionStatus(1, "sending");
        public static TransactionStatus Pending { get; } = new TransactionStatus(2, "pending");
        public static TransactionStatus Approved { get; } = new TransactionStatus(3, "approved");
        public static TransactionStatus Rejected { get; } = new TransactionStatus(4, "rejected");
        public static TransactionStatus Done { get; } = new TransactionStatus(5, "done");
        public static TransactionStatus Cancelled { get; } = new TransactionStatus(6, "cancelled");
        public static TransactionStatus Errored { get; } = new TransactionStatus(7, "errored");
        public static TransactionStatus Fueling { get; } = new TransactionStatus(8, "fueling");

        public string Name { get; private set; }
        public int Value { get; private set; }

        private TransactionStatus(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public static IEnumerable<TransactionStatus> List()
        {
            return new[] { Sending, Pending, Approved, Rejected, Done, Cancelled, Errored, Fueling };
        }

        public static TransactionStatus FromString(string name) => List().SingleOrDefault(r => string.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));

        public static TransactionStatus FromValue(int value) => List().SingleOrDefault(r => r.Value == value);
    }
}
