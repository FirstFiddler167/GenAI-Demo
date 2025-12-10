

---
# **GenAI-Demo**

**GenAI-Demo** is a complete learning and demonstration project showcasing how to build modern Generative AI applications using **.NET**, **Microsoft Extensions for AI (MEAI)**, **Semantic Kernel**, embeddings, RAG, function calling, and image analysis.

This repository walks you step-by-step through building real-world AI features and integrating Large Language Models (LLMs) into production-ready .NET solutions.

---

## 🚀 **What You Will Build & Learn**

### **💬 Chat & Text Intelligence**

Create intelligent chatbots, perform text classification, summarization, and sentiment analysis, and learn practical prompt engineering techniques.

### **🛠️ Function Calling (Tools)**

Teach your AI to execute real C# methods—allowing it to retrieve data, call external services, and perform real actions programmatically.

### **🔍 Vector Search & Embeddings**

Understand how modern semantic search works. Convert text into vector embeddings and build semantic search features powered by vector databases.

### **📚 Retrieval-Augmented Generation (RAG)**

Build a complete RAG pipeline from scratch. Allow your AI to ground answers in your own documents for accurate, fact-based responses.

### **🖼️ Image Understanding**

Implement multimodal capabilities so the AI can analyze images, extract information, generate descriptions, and interpret visual content.

### **🏆 Final Project: Semantic Search**

Bring everything together by building a full semantic search engine for an platform using **.NET Aspire**, **Qdrant**, and models like **gpt-4o-mini**.

---

## 💻 **Technology Stack**

This demo uses a modern and production-ready stack:

* **.NET 10**
* **ASP.NET Core** (Minimal APIs, Blazor)
* **.NET Aspire** for service orchestration
* **OpenAI / GitHub Models** (gpt-4o-mini, text-embedding-3-small)
* **Ollama** (Llama 3.2, LLaVA, all-minilm locally)
* **Qdrant** Vector Database
* **Microsoft.Extensions.AI** Abstractions
* **Semantic Kernel**
* **Entity Framework Core + PostgreSQL**
* **Docker**

---

## 📂 **Repository Structure**

The repository is organized into sections that mirror the learning path. Each folder contains a standalone project:

| Folder                         | Description                                                            |
| ------------------------------ | ---------------------------------------------------------------------- |
| **01-TextCompletionSentiment** | Text generation, streaming, structured output, sentiment analysis      |
| **02-ChatApp**                 | Context-aware chatbot with memory                                      |
| **03-FunctionCalling**         | LLM executing C# functions                                             |
| **04-VectorSearch**            | Embeddings, similarity search, vector databases                        |
| **05-RAGApplication**          | Full Retrieval-Augmented Generation pipeline                           |
| **06-ImageAnalysis**           | Vision models and multimodal AI                                        |

---

## 🏁 **Getting Started**

### **Prerequisites**

Make sure you have:

* **.NET 10 SDK**
* **Docker Desktop** (required for Ollama & Qdrant)
* **Visual Studio 2026** or **VS Code** (with C# Dev Kit)

---

## ⚙️ **Configuration**

These projects use `.NET user-secrets` for secure storage of API keys.

### **1. GitHub Models / OpenAI API Key**

Navigate to any project folder (e.g., `01-TextCompletionSentiment`) and run:

```bash
dotnet user-secrets init
dotnet user-secrets set "GitHubModels:Token" "YOUR_GITHUB_PAT_HERE"
```

### **2. For .NET Aspire Final Project**

Navigate to the **AppHost** directory and configure the OpenAI/GitHub Models connection:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:openai" "Endpoint=https://models.inference.ai.azure.com;Key=YOUR_GITHUB_PAT_HERE"
```

---

