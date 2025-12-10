# GenAI-Demo

🚀 What You'll Build and Learn

Throughout this course, you will get hands-on experience building a variety of real-world AI applications:

💬 Chat & Text Analysis: Build your first intelligent chatbots, perform complex text analysis (classification, summarization, sentiment analysis), and master prompt engineering to control AI behavior.

🛠️ Function Calling: Give your AI a "superpower" by teaching it to execute your own C# methods to fetch real-time data or perform actions.

🔍 Vector Search & Embeddings: Learn the core of all modern recommendation engines. Turn any text into a numerical vector of its "meaning" and perform powerful semantic searches.

📚 Retrieval-Augmented Generation (RAG): Construct a complete RAG pipeline from scratch. Build an AI that can answer questions based on your own private documents, grounding its responses in facts and eliminating hallucinations.

🖼️ Image Analysis: Go beyond text and give your AI the gift of sight. Build applications that can "see" and interpret the contents of an image, and even extract structured data from what they see, like monitoring traffic cameras.

🏆 Final Project: E-Shop Semantic Search: Put all your skills together to build a complete AI-powered eShop application. You will implement a cutting-edge semantic search feature in a distributed microservices application using .NET Aspire, a Qdrant Vector Database, and models like gpt-4o-mini.

💻 Technology Stack
We use a modern, powerful, and production-ready tech stack:

.NET 10
ASP.NET Core (Minimal APIs, Blazor)
.NET Aspire for orchestration
OpenAI / GitHub Models (gpt-4o-mini, text-embedding-3-small)
Ollama (Llama 3.2, LLaVA, all-minilm)
Qdrant Vector Database
Microsoft.Extensions.AI Abstractions
Entity Framework Core & PostgreSQL
Docker
📂 Repository Structure
This repository is organized by section, mirroring the structure of the Udemy course. Each numbered folder represents a self-contained project that we build together.

01-TextCompletionSentiment: Fundamentals of text generation, streaming, structured output, and analysis.
02-ChatApp: Building an interactive, context-aware chatbot.
03-FunctionCalling: Enabling the LLM to execute C# code.
04-VectorSearch: Introduction to embeddings and vector databases.
05-RAGApplication: Building a complete RAG app with a custom knowledge base.
06-ImageAnalysis: Multimodal AI with vision models.
07-EShopVectorSearch: The final capstone project using .NET Aspire and microservices.
🏁 Getting Started
Prerequisites
To run these projects, you will need the following installed on your machine:

.NET 9 SDK (or later)
Docker Desktop (essential for Ollama and Qdrant)
An IDE like Visual Studio 2022 or Visual Studio Code (with the C# Dev Kit).
Configuration
These projects require API keys to connect to AI services. We use .NET's user-secrets feature to keep these keys safe and out of source control.

1. For OpenAI / GitHub Models:

Navigate to a project directory (e.g., 01-TextCompletionSentiment) in your terminal and run:


dotnet user-secrets init
dotnet user-secrets set "GitHubModels:Token" "YOUR_GITHUB_PAT_HERE"

For the Project (using .NET Aspire): Configuration is handled by the .AppHost project. Navigate to the EShopVectorSearch.AppHost directory and set the secret there:

dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:openai" "Endpoint=https://models.inference.ai.azure.com;Key=YOUR_GITHUB_PAT_HERE"
