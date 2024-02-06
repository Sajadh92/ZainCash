using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace Infrastructure.EPay;

public static class ZainCash
{
    private static byte[] Key => Encoding.ASCII.GetBytes(ZainCashKey.MerchantSecret);
    private static string JwtToken(object data) => Jose.JWT.Encode(data, Key, Jose.JwsAlgorithm.HS256);
    private static FormUrlEncodedContent Payload(object data) => new
    (
        new List<KeyValuePair<string, string>>
        {
            new("token", HttpUtility.UrlEncode(JwtToken(data))),
            new("merchantId", ZainCashKey.MerchantId),
            new("lang", ZainCashKey.Lang)
        }
    );

    private static int ExpireAt => (int)DateTime.UtcNow
        .AddHours(ZainCashKey.OffsetHours)
        .AddMinutes(ZainCashKey.ExpireMinutes)
        .Subtract(new DateTime(1970, 1, 1))
        .TotalSeconds;

    public static async Task<ZainCashInitResponse> Init(ZainCashInitModel model)
    {
        IDictionary<string, object> data = new Dictionary<string, object>
        {
            { "serviceType", model.ServiceType },
            { "orderId", model.OrderId },
            { "amount", model.Amount },
            { "msisdn", ZainCashKey.MSISDN },
            { "redirectUrl", ZainCashKey.RedirectUrl },
            { "iat", 0 },
            { "exp", ExpireAt },
        };

        using HttpClient httpClient = new();

        HttpResponseMessage response = await httpClient.PostAsync(ZainCashKey.ApiInitUrl, Payload(data));

        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            ZainCashInitResponse? initResponse = JsonConvert.DeserializeObject<ZainCashInitResponse>(responseContent);

            if (initResponse!.Id == null)
            {
                ZainCashError? error = JsonConvert.DeserializeObject<ZainCashError>(responseContent);

                throw new Exception(error!.Err.Msg);
            }

            initResponse.PaymentUrl = ZainCashKey.ApiPayUrl(initResponse.Id);

            return initResponse;
        }
        else
        {
            throw new Exception("Error: " + response.StatusCode);
        }
    }

    public static async Task<ZainCashGetResponse> Get(string id)
    {
        IDictionary<string, object> data = new Dictionary<string, object>
        {
            { "id", id },
            { "msisdn", ZainCashKey.MSISDN },
            { "iat", 0 },
            { "exp", ExpireAt }
        };

        using HttpClient httpClient = new();

        HttpResponseMessage response = await httpClient.PostAsync(ZainCashKey.ApiGetUrl, Payload(data));

        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            ZainCashGetResponse? getResponse = JsonConvert.DeserializeObject<ZainCashGetResponse>(responseContent);

            if (getResponse!.Id == null)
            {
                ZainCashError? error = JsonConvert.DeserializeObject<ZainCashError>(responseContent);

                throw new Exception(error!.Err.Msg);
            }

            return getResponse;
        }
        else
        {
            throw new Exception("Error: " + response.StatusCode);
        }
    }

    public static ZainCashPayResponse Verify(string token)
    {
        string data = Jose.JWT.Decode(token, Key, Jose.JwsAlgorithm.HS256);

        ZainCashPayResponse? response = JsonConvert.DeserializeObject<ZainCashPayResponse>(data);

        response!.IsSuccess = response.Status == "success";

        return response!;
    }
}
