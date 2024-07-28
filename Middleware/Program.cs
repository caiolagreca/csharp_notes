var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configuração dos Middlewares
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<div> Hello World from the middleware 1 </div>");
    await next.Invoke();
    await context.Response.WriteAsync("<div> Returning from the middleware 1 </div>");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<div> Hello World from the middleware 2 </div>");
    await next.Invoke();
    await context.Response.WriteAsync("<div> Returning from the middleware 2 </div>");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("<div> Hello World from the middleware 3 </div>");
});

// Executar o Aplicativo
app.Run();

/* OUTPUT
Hello World from the middleware 1
Hello World from the middleware 2
Hello World from the middleware 3
Returning from the middleware 2
Returning from the middleware 1
 */
