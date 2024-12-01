var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext httpContext) =>
{

    if (httpContext.Request.Method == HttpMethod.Get.ToString())
    {
        if (httpContext.Request.Path.StartsWithSegments("/"))
        {
            await httpContext.Response.WriteAsync($"Request method : {httpContext.Request.Method}\r\n");

            await httpContext.Response.WriteAsync($"\r\nQueries\r\n");

            foreach (var query in httpContext.Request.Query)
            {
                await httpContext.Response.WriteAsync($"{query.Key} : {query.Value}\r\n");
            }

            await httpContext.Response.WriteAsync($"\r\nHeaders\r\n");

            foreach (var header in httpContext.Request.Headers)
            {
                await httpContext.Response.WriteAsync($"{header.Key} : {header.Value}\r\n");
            }

            await httpContext.Response.WriteAsync($"\r\nCookies\r\n");
            foreach (var cookie in httpContext.Request.Cookies)
            {
                await httpContext.Response.WriteAsync($"{cookie.Key} : {cookie.Value}\r\n");
            }
        }
        else if(httpContext.Request.Path.StartsWithSegments("/employee")){
            await httpContext.Response.WriteAsync("Employees");
        }
    }
});

app.Run();
