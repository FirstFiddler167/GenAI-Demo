using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<CatalogDbContext>( connectionName: "catalogdb" );

builder.Services.AddScoped<ProductAIService>();
builder.Services.AddScoped<ProductService>();

// Add AI Chat Client
var credential = new ApiKeyCredential( builder.Configuration [ "GitHubModels:Token" ] ?? throw new InvalidOperationException( "Missing configuration: GitHubModels:Token." ) );
var options = new OpenAIClientOptions()
{
    Endpoint = new Uri( "https://models.github.ai/inference" )
};

var openAiClient = new OpenAIClient( credential , options );

var chatClient =
    openAiClient.GetChatClient( "openai/gpt-4.1-mini" ).AsIChatClient(); // if not worked use: gpt-4o-mini

var embeddingGenerator =
    openAiClient.GetEmbeddingClient( "openai/text-embedding-3-small" ).AsIEmbeddingGenerator();

builder.Services.AddChatClient( chatClient );
builder.Services.AddEmbeddingGenerator( embeddingGenerator );

// Add Vector DB Search Operations
builder.AddQdrantClient( "vectordb" );
builder.Services.AddQdrantCollection<ulong , ProductVector>( "product-vectors" );



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI( options =>
    {
        options.SwaggerEndpoint( "/openapi/v1.json" , "Catalog API" );
        options.RoutePrefix = "";  // Swagger at root URL
    } );
}
;
app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseMigration();

app.MapProductEndpoints();

app.Run();
