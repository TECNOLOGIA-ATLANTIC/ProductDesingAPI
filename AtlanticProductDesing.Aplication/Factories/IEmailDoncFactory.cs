using AtlanticProductDesing.Application.Models;

namespace AtlanticProductDesing.Application.Factories
{
    public interface IEmailDoncFactory
    {
        Email BuildEmailDonc(string body);
    }
}
