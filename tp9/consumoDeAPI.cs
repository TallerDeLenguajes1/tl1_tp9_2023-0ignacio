using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace clasesConsumoAPI
{
    public class ConsumirAPIPrecios
    {
        public static PrecioBC GetPrecios()
        {
            var url = $"https://api.coindesk.com/v1/bpi/currentprice.json";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try{
                using(WebResponse response = request.GetResponse())
                {
                    using(Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            PrecioBC? precios = JsonSerializer.Deserialize<PrecioBC>(responseBody);
                            Console.WriteLine($"Tasa USD: {WebUtility.HtmlDecode(precios.Bpi.USD.Symbol)}{precios.Bpi.USD.Rate}");
                            Console.WriteLine($"Tasa GBP: {WebUtility.HtmlDecode(precios.Bpi.GBP.Symbol)}{precios.Bpi.GBP.Rate}");
                            Console.WriteLine($"Tasa EUR: {WebUtility.HtmlDecode(precios.Bpi.EUR.Symbol)}{precios.Bpi.EUR.Rate}");
                            return precios;
                        }
                    }
                }
            }
            catch (DuplicateWaitObjectException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
                return null;
            }
        }
    }
    
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class PrecioBC
    {
        [JsonPropertyName("time")]
        public Time Time { get; set; }

        [JsonPropertyName("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonPropertyName("chartName")]
        public string ChartName { get; set; }

        [JsonPropertyName("bpi")]
        public Bpi Bpi { get; set; }
    }

    public class Time
    {
        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("updatedISO")]
        public DateTime UpdatedISO { get; set; }

        [JsonPropertyName("updateduk")]
        public string Updateduk { get; set; }
    }

    public class Bpi
    {
        [JsonPropertyName("USD")]
        public USD USD { get; set; }

        [JsonPropertyName("GBP")]
        public GBP GBP { get; set; }

        [JsonPropertyName("EUR")]
        public EUR EUR { get; set; }
    }

    public class EUR
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("rate")]
        public string Rate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("rate_float")]
        public double Rate_float { get; set; }
    }

    public class GBP
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("rate")]
        public string Rate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("rate_float")]
        public double Rate_float { get; set; }
    }

    public class USD
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("rate")]
        public string Rate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("rate_float")]
        public double Rate_float { get; set; }
    }

}