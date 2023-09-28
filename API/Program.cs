using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient();

builder.Services.AddControllers();
//builder.Services.AddSwaggerGen(c =>
//{
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath);
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "Zip Tips API",
//        Version = "v1",
//        Description = "",
//        Contact = new OpenApiContact
//        {
//            Name = "Tylor Krafjack",
//            Email = "TKrafjack@gmai.com",
//            Url = new Uri(""),
//        }
//    });
//});

builder.Services.AddHttpClient("ExchangeRateData", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["CurrencyConverterService:APIURL"]);
    httpClient.DefaultRequestHeaders.Add("apikey", builder.Configuration["CurrencyConverterService:APIKEY"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
