
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;
using OllamaSharp;
using VectorSearchOllama;

// Create the embedding generator
IEmbeddingGenerator<string , Embedding<float>> generator =
    new OllamaApiClient( new Uri( "http://localhost:11434/" ) , "all-minilm" );


// Create and populate the vector store
var vectorStore = new InMemoryVectorStore();

var moviesStore = vectorStore.GetCollection<int , Movie>( "movies" );

await moviesStore.EnsureCollectionExistsAsync();

foreach ( var movie in MovieData.Movies )
{
    // generate the embedding vector for the movie description
    var descEmbedding = await generator.GenerateVectorAsync( movie.Description );
    movie.DescriptionVector = descEmbedding;
    // generate the embedding vector for the movie title
    var titleEmbedding = await generator.GenerateVectorAsync( movie.Title );
    movie.TitleVector = titleEmbedding;


    movie.SearchVector = CombineEmbeddings( titleEmbedding , descEmbedding );

    // add the overall movie to the in-memory vector store's movie collection
    await moviesStore.UpsertAsync( movie );
}
//1-Embed the user’s query
//2-Vectorized search
//3-Returns the records

// generate the embedding vector for the user's prompt
var query = "Lion King is a classic Disney animated film that tells the story of a young lion named Simba";
//var query = "I want to see family friendly movie";
//var query = "A science fiction movie about space travel";
//var query = "Interstellar movie is a science fiction movie about space travel";
var queryEmbedding = await generator.GenerateVectorAsync( query );

// Choose which vector property to search on:
var optionSearch = new VectorSearchOptions<Movie>
{
    // pick ONE of your vector properties:
    VectorProperty = m => m.SearchVector ,          // or m => m.ReviewEmbedding
     Skip = 2,
    IncludeVectors = true                          // optional: don’t return vectors
};


// search the knowledge store based on the user's prompt
var searchResults = moviesStore.SearchAsync( queryEmbedding , top: 2 , optionSearch );


// see the results just so we know what they look like
await foreach ( var result in searchResults )
{
    Console.WriteLine( $"Title: {result.Record.Title}" );
    Console.WriteLine( $"Description: {result.Record.Description}" );
    Console.WriteLine( $"Score: {result.Score}" );
    Console.WriteLine();
}
Console.ReadKey();

ReadOnlyMemory<float> CombineEmbeddings ( ReadOnlyMemory<float> a , ReadOnlyMemory<float> b )
{
    var aSpan = a.Span;
    var bSpan = b.Span;

    if ( aSpan.Length != bSpan.Length )
        throw new InvalidOperationException( "Embeddings must have same dimension." );

    var combined = new float [ aSpan.Length ];
    for ( int i = 0 ; i < combined.Length ; i++ )
    {
        combined [ i ] = ( aSpan [ i ] + bSpan [ i ] ) / 2f; // average
    }

    return combined;
}