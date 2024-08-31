namespace Reservei_API.Objects.Contracts
{
    public class TokenSignatures
    {
        public string Issuer { get; set; } = "Reservei_API";

        public string Audience { get; set; } = "Reservei_API WebSite";

        public string Key { get; } = "Reservei_API_Barrament_API_AUtentication";
    }
}
