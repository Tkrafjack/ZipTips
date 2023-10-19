using Infrastructure.Injection;

var builder = WebApplication.CreateBuilder(args);
{
    InfrastructureInjectionExtensions.AddInfrastructureServices(builder.Services);
    builder.Services.AddControllers();
}

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("censusBusinessMetrics", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.census.gov/data/2018/zbp");
});

builder.Services.AddHttpClient("zippopotamus", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://api.zippopotam.us/us/");
});

builder.Services.AddHttpClient("rentCast", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.rentcast.io/v1/markets?");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//needed **look up what this does**
app.MapControllers();

app.Run();

//TODO: remove Razor and replace with React frontend
//TODO: change swagger url path