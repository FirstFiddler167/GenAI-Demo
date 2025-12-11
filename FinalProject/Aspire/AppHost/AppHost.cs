using Projects;

var builder = DistributedApplication.CreateBuilder( args );

// Backing Services
var postgres = builder
        .AddPostgres( "postgres" )
        .WithPgAdmin( pgAdmin => pgAdmin.WithUrlForEndpoint( "http" , url => url.DisplayText = "PostgreDB Browser" ) )
        .WithDataVolume()
        .WithLifetime( ContainerLifetime.Persistent );

var vectordb = builder
    .AddQdrant( "vectordb" )
    .WithDataVolume();

var cache = builder
        .AddRedis( "cache" )
        .WithRedisInsight()
        .WithDataVolume()
        .WithLifetime( ContainerLifetime.Persistent );

var sqlServer = builder
        .AddSqlServer( "sqlserver" )
        .WithDataVolume()
        .WithLifetime( ContainerLifetime.Persistent );

var orderdb = sqlServer.AddDatabase( "orderdb" );

var catalogdb = postgres.AddDatabase( "catalogdb" );

var basket = builder.AddProject<Projects.Basket>( "basket" )
                    .WithReference( cache )
                    .WaitFor( cache );

// Projects
var catalog = builder.AddProject<Projects.Catalog>( "catalog" )
                     .WithReference( catalogdb )
                     .WaitFor( catalogdb )
                     .WithReference( vectordb )
                     .WaitFor( vectordb );


var ordering = builder
        .AddProject<Projects.Ordering>( "ordering" )
        .WithReference( orderdb )
        .WaitFor( orderdb );
// for simplicity basket checkout performed sync call basket to ordering
basket
    .WithReference( ordering )
    .WaitFor( ordering );



builder.AddProject<Projects.WebApp>( "webapp" )
       .WithExternalHttpEndpoints()
       .WithUrlForEndpoint( "https" , url => url.DisplayText = "EShop WebApp (HTTPS)" )
       .WithUrlForEndpoint( "http" , url => url.DisplayText = "EShop WebApp (HTTP)" )
       .WithReference( catalog )
       .WaitFor( catalog )
       .WithReference( basket )
       .WaitFor( basket )
       .WithReference( ordering )
       .WaitFor( ordering );

builder.Build().Run();
