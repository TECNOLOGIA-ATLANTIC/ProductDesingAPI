namespace AtlanticProductDesing.Application.Enums
{
    public class TransactionStatusResponse
    {
        public static TransactionStatusResponse Sending { get; } = new TransactionStatusResponse(1, "Enviado");
        public static TransactionStatusResponse Pending { get; } = new TransactionStatusResponse(2, "Pendiente");
        public static TransactionStatusResponse Approved { get; } = new TransactionStatusResponse(3, "Aprobado");
        public static TransactionStatusResponse Rejected { get; } = new TransactionStatusResponse(4, "Rechazado");
        public static TransactionStatusResponse Done { get; } = new TransactionStatusResponse(5, "Completado");
        public static TransactionStatusResponse Cancelled { get; } = new TransactionStatusResponse(6, "Cancelado");
        public static TransactionStatusResponse Errored { get; } = new TransactionStatusResponse(7, "Errado");

        public string Name { get; private set; }
        public int Value { get; private set; }

        private TransactionStatusResponse(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public static IEnumerable<TransactionStatusResponse> List()
        {
            return new[] { Sending, Pending, Approved, Rejected, Done, Cancelled, Errored };
        }

        public static TransactionStatusResponse FromString(string name) => List().SingleOrDefault(r => String.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));

        public static TransactionStatusResponse FromValue(int value) => List().SingleOrDefault(r => r.Value == value);
    }
}
