using System.Net.Http.Json;

HttpClient client = new();

//1
//object? data = await client.GetFromJsonAsync("https://localhost:7229/", typeof(Employee));

//if(data is Employee emplyee)
//{
//    Console.WriteLine($"Name: {emplyee.Name}, Age: {emplyee.Age}");
//}


//2
using var response = await client.GetAsync("https://localhost:7229/10");
if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.NotFound)
{
    Error? error = await response.Content.ReadFromJsonAsync<Error>();
    Console.WriteLine($"Code: {response.StatusCode}, Message: {error.Message}");
}
else
{
    Employee? employee = await response.Content.ReadFromJsonAsync<Employee>();
    Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Age: {employee.Age}");
}


class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}

class Error
{
    public string? Message { get; set; }
}