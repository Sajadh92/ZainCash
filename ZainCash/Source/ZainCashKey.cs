namespace Infrastructure.EPay;

public enum Environment
{
    Development,
    Production,
    LocalHost
}

public static class ZainCashKey
{
    public static Environment Environment => Environment.Development;
    public static int OffsetHours => 3;
    public static int ExpireMinutes => 30;
    public static string Lang => "ar";

    private static string ApiBaseUrl => Environment == Environment.Production
        ? "https://api.zaincash.iq/transaction"
        : "https://test.zaincash.iq/transaction";

    public static string ApiInitUrl => $"{ApiBaseUrl}/init";
    public static string ApiGetUrl => $"{ApiBaseUrl}/get";
    public static string ApiPayUrl(string id) => $"{ApiBaseUrl}/pay?id={id}";

    public static string RedirectUrl =>
        Environment == Environment.Development ? "https://dev.domain.com/epay/zaincash/redirect" :
        Environment == Environment.Production ? "https://domain.com/epay/zaincash/redirect" :
        Environment == Environment.LocalHost ? "http://localhost:3000/epay/zaincash/redirect" : "";

    public static string MSISDN => Environment == Environment.Production
        ? "Your Production Wallet Phone Number"
        : "9647835077893";

    public static string MerchantId => Environment == Environment.Production
        ? "Your Production Merchant Id"
        : "5ffacf6612b5777c6d44266f";

    public static string MerchantSecret => Environment == Environment.Production
        ? "Your Production Merchant Secret"
        : "$2y$10$hBbAZo2GfSSvyqAyV2SaqOfYewgYpfR1O19gIh4SqyGWdmySZYPuS";
}
