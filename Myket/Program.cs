using Myket;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<HttpProductsService>();
builder.Services.AddScoped<IProductsService>(provider =>
    new CacheProductsService(provider.GetRequiredService<HttpProductsService>())); ;

builder.Services.AddScoped<IProductDetail, TorobProductDetail>();
builder.Services.AddScoped<IProductDetail, DigikalaProductDetails>();

builder.Services.AddControllers();
builder.Services.AddHttpClient();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
