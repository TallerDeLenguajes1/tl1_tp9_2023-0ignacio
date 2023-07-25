using System.Net;
using clasesConsumoAPI;
internal class Program
{
    private static void Main(string[] args)
    {
        int aux;
        PrecioBC precios = ConsumirAPIPrecios.GetPrecios();

        if (precios == null)
        {
            Console.WriteLine("No se pudo obtener la información de la API. Saliendo del programa...");
            return;
        }

        Console.WriteLine("1 - USD");
        Console.WriteLine("2 - EUR");
        Console.WriteLine("3 - GBP");
        Console.WriteLine("De que moneda quieres ver informacion?");
        int.TryParse(Console.ReadLine(), out aux);
        switch (aux)
        {
            case 1:
                Console.WriteLine("Moneda: USD");
                Console.WriteLine($"Code: {precios.Bpi.USD.Code}");
                Console.WriteLine($"Symbol: {WebUtility.HtmlDecode(precios.Bpi.USD.Symbol)}");
                Console.WriteLine($"Rate: {precios.Bpi.USD.Rate}");
                Console.WriteLine($"Description: {precios.Bpi.USD.Description}");
                Console.WriteLine($"Rate_Float: {precios.Bpi.USD.Rate_float}");
                break;
            case 2:
                Console.WriteLine("Moneda: EUR");
                Console.WriteLine($"Code: {precios.Bpi.EUR.Code}");
                Console.WriteLine($"Symbol: {WebUtility.HtmlDecode(precios.Bpi.EUR.Symbol)}");
                Console.WriteLine($"Rate: {precios.Bpi.EUR.Rate}");
                Console.WriteLine($"Description: {precios.Bpi.EUR.Description}");
                Console.WriteLine($"Rate_Float: {precios.Bpi.EUR.Rate_float}");
                break;
            case 3:
                Console.WriteLine("Moneda: GBP");
                Console.WriteLine($"Code: {precios.Bpi.GBP.Code}");
                Console.WriteLine($"Symbol: {WebUtility.HtmlDecode(precios.Bpi.GBP.Symbol)}");
                Console.WriteLine($"Rate: {precios.Bpi.GBP.Rate}");
                Console.WriteLine($"Description: {precios.Bpi.GBP.Description}");
                Console.WriteLine($"Rate_Float: {precios.Bpi.GBP.Rate_float}");
                break;
            default:
                break;
        }
    }
}