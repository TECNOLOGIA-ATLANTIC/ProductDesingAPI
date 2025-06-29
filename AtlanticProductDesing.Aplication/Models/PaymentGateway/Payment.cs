namespace AtlanticProductDesing.Application.Models.PaymentGateway
{
    /// <summary>
    /// Clase para enviar datos del pago
    /// Si no tienen el token card debe enviar el CrediCart (seguramente es la primera vez que el cliente paga con esa tarjeta)
    /// Si ya tiene registrado el TokenCard puede enviarlo para evitar enviar los datos completos de la tarjeta
    /// </summary>
    public class Payment
    {
        public Payment(CreditCard credicard)
        {
            this.CreditCard = credicard;
            this.Order = new Order();
        }
        public Payment(TokenCard tokenCard)
        {
            this.TokenCard = tokenCard;
            this.Order = new Order();
        }

        public int PaymentMethodId { get; set; }
        public double Amount { get; set; }
        public string MerchantId { get; set; }
        public Order Order { get; set; }
        public CreditCard? CreditCard { get; set; }
        public TokenCard? TokenCard { get; set; }
    }
}
