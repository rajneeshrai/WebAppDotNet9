using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using WebAppDotnet9;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
// app.MapGet("/", () => "Hello World!");
// app.Use(async (HttpContext context, RequestDelegate next) =>
// {
//     await context.Response.WriteAsync("Before first middleware execution!\r\n");
//     await next(context);
//     await context.Response.WriteAsync("After first middleware execution!\r\n");
// });

// app.Map("/employees", appBuilder =>
// {
//     appBuilder.MapWhen((context) =>
//     {
//         return context.Request.Query.ContainsKey("id");
//     },
//     (config) =>
//     {
//         config.Use(async (context, next) =>
//     {
//         await context.Response.WriteAsync("Before MapWhen middleware execution!\r\n");
//         await next(context);
//         await context.Response.WriteAsync("After MapWhen middleware execution!\r\n");
//     });
//     });
//     appBuilder.Use(async (context, next) =>
//     {
//         await context.Response.WriteAsync("Before Fourth middleware execution!\r\n");
//         await next(context);
//         await context.Response.WriteAsync("After Fourth middleware execution!\r\n");
//     });

//     appBuilder.Use(async (context, next) =>
//     {
//         await context.Response.WriteAsync("Before Fifth middleware execution!\r\n");
//         await next(context);
//         await context.Response.WriteAsync("After Fifth middleware execution!\r\n");
//     });
// });

// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("Before Second middleware execution!\r\n");
//     await next(context);
//     await context.Response.WriteAsync("After Second middleware execution!\r\n");
// });

// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("Before Third middleware execution!\r\n");
//     await next(context);
//     await context.Response.WriteAsync("After Third middleware execution!\r\n");
// });

// app.Run(async (context) =>
// {
//     await context.Response.WriteAsync("Processed!\r\n");
// });



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
