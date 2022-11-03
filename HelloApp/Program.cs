using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RequestDelegate request = async (context) => await context.Response.WriteAsync("Hello METANIT.COM");

//RequestAndResponse(app);
//Pictures(app);
HtmlPage(app);

void HtmlPage(WebApplication app)
{
	app.Run(async (context) =>
	{
		context.Response.ContentType = "text/html; charset=utf-8";
		await context.Response.SendFileAsync("html/index.html");
	});
}

void Pictures(WebApplication app)
{
	//app.Run(async (context) => await context
	//.Response
	//.SendFileAsync(@"E:\обои\Новая папка\%3F%3F%3F%3F%3F%3F%3F%3F_%3F%3F%3F%3F_%3F%3F%3F%3F%3F%3F%3F.png"));

	app.Run(async (context) => await context.Response.SendFileAsync("Mona.png"));
}

//app.UseWelcomePage();   // подключение WelcomePageMiddleware
//app.Run(request);
app.Run();


//app.MapGet("/", () => "Hello World!");
//app.MapGet("/lox", () => "ты лох!");
//app.UseWelcomePage();


//app.Start();
//await Task.Delay(10000);
//await app.StopAsync();

void RequestAndResponse(WebApplication app)
{
	int x = 2;
	app.Run(async (context) =>
	{
		var response = context.Response;
		response.Headers.ContentLanguage = "ru-RU";
		response.Headers.ContentType = "text/html; charset=utf-8";
		response.Headers.Append("secret-id", "256");
		response.StatusCode = 404;
		x = x + 2;  //  2 * 2 = 4

		var sb = new StringBuilder("<table>");
		sb.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
		foreach (var h in context.Response.Headers)
		{
			sb.Append($"<tr><td>{h.Key}</td><td>{h.Value}</td></tr>");
		}
		foreach (var h in context.Request.Headers)
		{
			sb.Append($"<tr><td>{h.Key}</td><td>{h.Value}</td></tr>");
		}
		foreach (var p in context.Request.Query)
		{
			sb.Append($"<tr><td>{p.Key}</td><td>{p.Value}</td></tr>");
		}
		sb.Append("</table>");
		string name = context.Request.Query["name"];
		var age = context.Request.Query["age"];
		Console.WriteLine($"{name} - {age}");

		//await context.Response.WriteAsync($"Result: {x}");
		Console.WriteLine(x);

		var path = context.Request.Path;
		var now = DateTime.Now;

		if (path == "/date")
			await response.WriteAsync($"Date: {now.ToShortDateString()}");
		else if (path == "/time")
			await response.WriteAsync($"Time: {now.ToShortTimeString()}");
		else
			await response.WriteAsync($"<h2>Hello METANIT.COM</h2><h3>Welcome to ASP.NET Core</h3><h1>Result: {x}</h1>{sb.ToString()}<h4>{context.Request.Path}</h4>");
	});
}