using Microsoft.Extensions.DependencyInjection;

//Console.WriteLine("App begin");

//for(int i = 0; i < 10; i++)
//{
//    using(var client  = new HttpClient())
//    {
//        using var result = await client.GetAsync("https://yandex.ru");
//        Console.WriteLine(result.StatusCode);
//    }
//}

//Console.WriteLine("App end");


ServiceCollection services = new();
services.AddHttpClient();

var serviceProvider = services.BuildServiceProvider();
var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

using (var client = httpClientFactory?.CreateClient())
{
    //using HttpRequestMessage request = new(HttpMethod.Get, "https://code.mu/ru");
    //using HttpResponseMessage response = await client.GetAsync("https://code.mu/ru");

    var responseStream = await client.GetStreamAsync("https://code.mu/ru");

    var reader = new StreamReader(responseStream);
    var response = await reader.ReadToEndAsync();

    Console.WriteLine(response);

    /*
    Console.WriteLine($"Status Code: {response.StatusCode}");
    Console.WriteLine($"Headers:");
    foreach(var head in response.Headers)
    {
        Console.Write($"Header key: {head.Key}, Value: ");
        foreach (var value in head.Value)
            Console.Write($"{value}, ");
        Console.WriteLine();
    }
    Console.WriteLine();

    Console.WriteLine($"Content:");
    Console.WriteLine(await response.Content.ReadAsStringAsync());
    */

}



