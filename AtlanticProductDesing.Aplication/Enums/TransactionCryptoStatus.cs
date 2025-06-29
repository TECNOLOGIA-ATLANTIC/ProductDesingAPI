namespace AtlanticProductDesing.Application.Enums
{
    public class TransactionCryptoStatus
    {
        public static TransactionCryptoStatus Created { get; } = new TransactionCryptoStatus(1, "created");
        public static TransactionCryptoStatus Cancelled { get; } = new TransactionCryptoStatus(2, "cancelled");
        public static TransactionCryptoStatus Paid { get; } = new TransactionCryptoStatus(3, "paid");
        public static TransactionCryptoStatus Overpaid { get; } = new TransactionCryptoStatus(4, "overpaid");
        public static TransactionCryptoStatus Underpaid { get; } = new TransactionCryptoStatus(5, "underpaid");
        public static TransactionCryptoStatus Rejected { get; } = new TransactionCryptoStatus(6, "rejected");
        public static TransactionCryptoStatus Expired { get; } = new TransactionCryptoStatus(7, "expired");

        public string Name { get; private set; }
        public int Value { get; private set; }

        private TransactionCryptoStatus(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public static IEnumerable<TransactionCryptoStatus> List()
        {
            return new[] { Created, Cancelled, Paid, Overpaid, Underpaid, Rejected, Expired };
        }

        public static TransactionCryptoStatus FromString(string name)
        {
            return List().SingleOrDefault(r => String.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public static TransactionCryptoStatus FromValue(int value)
        {
            return List().SingleOrDefault(r => r.Value == value);
        }
    }
}
