var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RequestDelegate request = async (context) => await context.Response.WriteAsync("Hello METANIT.COM");

int x = 2;
app.Run(async (context) =>
{
	x = x * 2;  //  2 * 2 = 4
	await context.Response.WriteAsync($"Result: {x}");
});

//app.UseWelcomePage();   // подключение WelcomePageMiddleware
//app.Run(request);
app.Run();


//app.MapGet("/", () => "Hello World!");
//app.MapGet("/lox", () => "ты лох!");
//app.UseWelcomePage();


//app.Start();
//await Task.Delay(10000);
//await app.StopAsync();
