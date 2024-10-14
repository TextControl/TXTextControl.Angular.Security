using TXTextControl.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();

// Add the TX Security Middleware to the request pipeline
app.UseMiddleware<TXTextControl.TXSecurityMiddleware>();

// TX Text Control specific middleware
app.UseTXWebSocketMiddleware();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
