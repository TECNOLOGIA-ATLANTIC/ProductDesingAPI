namespace AtlanticProductDesing.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) no fue encontrado")
        {

        }
        public NotFoundException(string name) : base(string.Format("({name}) no fue encontrado", name))
        {

        }
    }
}
