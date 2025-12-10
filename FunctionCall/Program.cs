// get credentials from user secrets
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OllamaSharp;
using OpenAI;
using System.ClientModel;

IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var credential = new ApiKeyCredential( config [ "GitHubModels:Token" ] ?? throw new InvalidOperationException( "Missing configuration: GitHubModels:Token." ) );
var options = new OpenAIClientOptions()
{
    Endpoint = new Uri( "https://models.github.ai/inference" )
};

// create a chat client openai/gpt-5-mini
IChatClient client =
    new ChatClientBuilder( new OpenAIClient( credential , options ).GetChatClient( "openai/gpt-4.1-mini" ).AsIChatClient() )
    .UseFunctionInvocation()
    .Build();


//IChatClient client = 
//    new ChatClientBuilder( new OllamaApiClient( new Uri( "http://localhost:11434" ) , "llama3.2" ) )
//    .UseFunctionInvocation()
//    .Build();

var chatOptions = new ChatOptions
{
    Tools = [AIFunctionFactory.Create((string location, string unit) =>
    {
        // Here you would call a weather API to get the weather for the location
        var temperature = Random.Shared.Next(5, 20);
        var conditions = Random.Shared.Next(0, 1) == 0 ? "sunny" : "rainy";

        return $"The weather is {temperature} degrees C and {conditions}.";
    },
    "get_current_weather",
    "Retrieve the current weather conditions for a specific location. " +
    "Use this function whenever the user asks about weather, temperature, " +
    "forecast, climate, or any weather-related information. " +
    "The function returns the temperature and conditions based on the selected unit.")]
};

List<ChatMessage> chatHistory = [
    //new( ChatRole.System , """
    //You are a hiking enthusiast who helps people discover fun hikes in their area. 
    //You are upbeat and friendly.
    //the answer should be shorted in one line and the line maxmuim 30 words and the answer must contain the degrees that return from my system and condition.
    //""" ) 
     new(ChatRole.System, """
        You are a hiking enthusiast who helps people discover fun hikes in their area.
        You are upbeat and friendly.

        ALWAYS call the tool `get_current_weather` when the user asks about weather.
        Your answer must:
        - Be ONE line only, maximum 30 words.
        - INCLUDE the exact temperature with F dagree and condition text returned by the tool.
        Do NOT invent your own temperature.
        """)

    ];

// Weather conversation relevant to the registered function.
chatHistory.Add( new( ChatRole.User , """
    I live in Istanbul and I'm looking for a moderate intensity hike. 
    What's the current weather like? 
    """ ) );

Console.WriteLine( $"{chatHistory.Last().Role} >>> {chatHistory.Last()}" );

ChatResponse response = await client.GetResponseAsync( chatHistory , chatOptions );

chatHistory.Add( new( ChatRole.Assistant , response.Text ) );

Console.WriteLine( $"{chatHistory.Last().Role} >>> {chatHistory.Last()}" );

Console.ReadKey();