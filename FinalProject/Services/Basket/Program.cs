var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.AddRedisDistributedCache( connectionName: "cache" );

builder.Services.AddScoped<BasketService>();

builder.Services.AddHttpClient<OrderingApiClient>( client =>
{
    client.BaseAddress = new( "https+http://ordering" );
} );

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.MapOpenApi();
    app.UseSwaggerUI( options =>
    {
        options.SwaggerEndpoint( "/openapi/v1.json" , "Basket API" );
        options.RoutePrefix = "";  // Swagger at root URL
    } );
}

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.MapBasketEndpoints();


app.Run();
