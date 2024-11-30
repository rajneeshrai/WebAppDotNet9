var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext httpContext) => {
    await httpContext.Response.WriteAsync($"Request method : {httpContext.Request.Method}\r\n");

    await httpContext.Response.WriteAsync($"\r\nQueries\r\n");

    foreach (var query in httpContext.Request.Query){
        await httpContext.Response.WriteAsync($"{query.Key} : {query.Value}\r\n");
    }

    await httpContext.Response.WriteAsync($"\r\nHeaders\r\n");

    foreach (var header in httpContext.Request.Headers){
        await httpContext.Response.WriteAsync($"{header.Key} : {header.Value}\r\n");
    }

    await httpContext.Response.WriteAsync($"\r\nCookies\r\n");
    foreach(var cookie in httpContext.Request.Cookies){
        await httpContext.Response.WriteAsync($"{cookie.Key} : {cookie.Value}\r\n");
    }
});

app.Run();
