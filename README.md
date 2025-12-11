---

# **GenAI-Demo**

### *Build Modern LLM Applications in .NET Using OpenAI, Ollama, Semantic Kernel, and .NET Aspire*

<img width="1371" height="489" alt="image" src="https://github.com/user-attachments/assets/cac480a5-e370-4530-a470-91376bba014a" />

---

## 🎓 **Overview**

This project is a **hands-on, end-to-end guide** to building generative AI applications in .NET—from basic chatbot scenarios to advanced distributed microservices powered by **.NET Aspire**, **Semantic Kernel**, vector databases, and both **cloud-based** (OpenAI/GitHub Models) and **local** (Ollama) LLMs.

The goal of this repository is to help .NET developers confidently build **AI-powered, production-ready software**.

---

## 🚀 **What You Will Build**

Throughout this project, you will build a wide range of real-world AI features and distributed services:

### 💬 **Chat & Text Analysis**

* Intelligent chatbots
* Prompt engineering
* Text classification, summarization & sentiment analysis

### 🛠️ **Function Calling (Tools)**

Enable LLMs to execute your own C# methods, integrate with external APIs, and perform real actions.

### 🔍 **Vector Search & Embeddings**

Convert text into embeddings and perform semantic search—the foundation of recommendation systems and knowledge bases.

### 📚 **Retrieval-Augmented Generation (RAG)**

Build a complete RAG pipeline using Semantic Kernel and vector stores.
Ground LLM answers in your **own documents** to eliminate hallucinations.

### 🖼️ **Image Analysis**

Use vision models to:

* Identify objects
* Extract information
* Interpret images
* Build AI-driven monitoring features

### 🏆 **Final Project: AI-Powered E-Shop with Semantic Search**

A fully distributed microservices system using:

* **.NET Aspire** for orchestration
* **Catalog** and **Basket** services
* **PostgreSQL, Redis, RabbitMQ, Keycloak**
* **Qdrant vector database**
* **Semantic Kernel** for RAG + semantic search
* **OpenAI & Ollama** for local/cloud LLMs

---

## 💻 **Technology Stack**

This solution uses a modern, enterprise-ready AI stack:

* **.NET 9**
* **ASP.NET Core** (Minimal APIs & Blazor)
* **.NET Aspire** – Orchestration & distributed applications
* **OpenAI / GitHub Models** (gpt-4o-mini, text-embedding-3-small)
* **Ollama** (Llama 3.2, LLaVA, all-minilm)
* **Qdrant** – Vector database for embeddings
* **Semantic Kernel**
* **Microsoft.Extensions.AI** abstractions
* **PostgreSQL**
* **Redis**
* **RabbitMQ**
* **Keycloak**
* **Docker**

---

## 📂 **Repository Structure**

Each folder represents a progressive module in the learning path:

| Module                         | Description                                                       |
| ------------------------------ | ----------------------------------------------------------------- |
| **01-TextCompletionSentiment** | Text generation, streaming, structured output, sentiment analysis |
| **02-ChatApp**                 | Context-aware conversational chat applications                    |
| **03-FunctionCalling**         | Execute C# functions from LLMs                                    |
| **04-VectorSearch**            | Build embeddings → semantic search engine                         |
| **05-RAGApplication**          | Complete RAG workflow with private documents                      |
| **06-ImageAnalysis**           | Work with multimodal (vision) LLMs                                |
| **07-FinalProject**            | Final microservices project with .NET Aspire                      |

---

## 🏁 **Getting Started**

### **Prerequisites**

Please install:

* **.NET 10 SDK**
* **Docker Desktop** (required for Ollama, Qdrant, RabbitMQ, PostgreSQL)
* **Visual Studio 2026** or **VS Code (C# Dev Kit)**

---

## ⚙️ **Configuration**

This repository uses `.NET user-secrets` to store API keys securely.

### **1. Configure OpenAI / GitHub Models**

Inside any module folder:

```bash
dotnet user-secrets init
dotnet user-secrets set "GitHubModels:Token" "YOUR_GITHUB_PAT_HERE"
```

### **2. Configure Final eShop Project (Aspire)**

Navigate to:

```
07-FinalProject\Aspire\AppHost
```

Then:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:openai" "Endpoint=https://models.inference.ai.azure.com;Key=YOUR_GITHUB_PAT_HERE"
```

---

## 🤝 **Contributing & Feedback**

This repository is intended for educational use.
If you discover issues, have suggestions, or want improvements:

👉 Please open an issue on GitHub — your feedback helps improve the course and this project.

---

## 📜 **License**

This project is licensed under the **MIT License**.
See the `LICENSE` file for more details.

---
