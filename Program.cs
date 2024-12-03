using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Before first middleware execution!\r\n");
    await next(context);
    await context.Response.WriteAsync("After first middleware execution!\r\n");
});

app.Use(async (context, next) => {
    await context.Response.WriteAsync("Before second middleware execution!\r\n");
    await next(context);
    await context.Response.WriteAsync("After second middleware execution!\r\n");
});

// app.Run(async (HttpContext httpContext) =>
// {

//     if (httpContext.Request.Method == HttpMethod.Get.ToString())
//     {
//         if (httpContext.Request.Path.StartsWithSegments("/"))
//         {
//             await httpContext.Response.WriteAsync($"Request method : {httpContext.Request.Method}\r\n");

//             await httpContext.Response.WriteAsync($"\r\nQueries\r\n");

//             foreach (var query in httpContext.Request.Query)
//             {
//                 await httpContext.Response.WriteAsync($"{query.Key} : {query.Value}\r\n");
//             }

//             await httpContext.Response.WriteAsync($"\r\nHeaders\r\n");

//             foreach (var header in httpContext.Request.Headers)
//             {
//                 await httpContext.Response.WriteAsync($"{header.Key} : {header.Value}\r\n");
//             }

//             await httpContext.Response.WriteAsync($"\r\nCookies\r\n");
//             foreach (var cookie in httpContext.Request.Cookies)
//             {
//                 await httpContext.Response.WriteAsync($"{cookie.Key} : {cookie.Value}\r\n");
//             }
//         }
//         else if (httpContext.Request.Path.StartsWithSegments("/employees"))
//         {
//             await httpContext.Response.WriteAsync("Employees\r\n");
//             EmployeeRepository.GetEmployees.ForEach(async (employee) =>
//             {
//                 await httpContext.Response.WriteAsync($"Id: {employee.Id},Name: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary}\r\n");
//             });
//         }
//     }
//     else if (httpContext.Request.Method == HttpMethod.Post.ToString())
//     {
//         if (httpContext.Request.Path.StartsWithSegments("/employees"))
//         {
//             StreamReader reader = new(httpContext.Request.Body);
//             var employee = JsonSerializer.Deserialize<Employee>(await reader.ReadToEndAsync());
//             EmployeeRepository.AddEmployee(employee);
//             await httpContext.Response.WriteAsync("Employee Added");
//         }
//     }
// });

app.Run();

static class EmployeeRepository
{
    private static List<Employee> _employees = [
            new Employee(1,"Rajneesh", "Tech Lead",1000),
            new Employee(2,"Rajat", "Manager",1500),
            new Employee(3,"Rajneesh", "Tech Lead",1000),
        ];
    public static List<Employee> GetEmployees => _employees;

    public static void AddEmployee(Employee? employee){
        if(employee is not null)
            _employees.Add(employee);
    }
}

public class Employee
{
    public Employee(int id, string name, string position, decimal salary)
    {
        this.Id = id;
        this.Name = name;
        this.Position = position;
        this.Salary = salary;
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public decimal Salary { get; set; }
}