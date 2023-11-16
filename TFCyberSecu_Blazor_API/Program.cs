using System.Data.SqlClient;
using TFCyberSecu_Blazor_API.Hubs;
using TFCyberSecu_Blazor_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("signalrPolicy", options =>
    options.WithOrigins("https://localhost:7106", "http://localhost:4200")
    .AllowAnyHeader().AllowCredentials().AllowAnyMethod())); ;


builder.Services.AddTransient(sp => 
    new SqlConnection(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IArticleService, ArticleService>();

builder.Services.AddSingleton<ArticleHub>();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("signalrPolicy");
app.UseHttpsRedirection();

//app.UseCors(o => o.AllowAnyOrigin().AllowCredentials().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("chathub");
app.MapHub<ArticleHub>("articlehub");

app.Run();
