namespace AtlanticProductDesing.Application.Enums
{
    public class TransactionType
    {
        public static TransactionType WireTransfer { get; } = new TransactionType(1, "Transferencia Bancaria");
        public static TransactionType CreditCardPayment { get; } = new TransactionType(2, "BudgetItemPay con Tarjeta de Crédito");
        public static TransactionType CryptoTransfer { get; } = new TransactionType(3, "Transferencia de Criptomoneda");
        public static TransactionType BuyTokenTransfer { get; } = new TransactionType(4, "Compra de Token");
        public static TransactionType ProjectClosure { get; } = new TransactionType(5, "Cierre de Proyecto");
        public static TransactionType CashOutTransfer { get; } = new TransactionType(6, "Retiro Transferencia Bancaria");
        public static TransactionType CashOutCrypto { get; } = new TransactionType(7, "Retiro Criptomoneda");


        public string Name { get; private set; }
        public int Value { get; private set; }

        private TransactionType(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public static IEnumerable<TransactionType> List()
        {
            return new[] { WireTransfer, CreditCardPayment, CryptoTransfer, BuyTokenTransfer, ProjectClosure, CashOutTransfer, CashOutCrypto };
        }

        public static TransactionType FromString(string name)
        {
            return List().SingleOrDefault(r => String.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public static TransactionType FromValue(int value)
        {
            return List().SingleOrDefault(r => r.Value == value);
        }
    }
}
