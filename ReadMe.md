# Welcome to SeeSharp WorkSharp 🚀

In a world full of tasks, deadlines, and the occasional forgotten grocery item, having a Todo Web API at your disposal can be a game-changer. Whether you're organizing your own life or building the next big productivity app, this guide will walk you through the process.

# Day 1
Congratulations on embarking on this journey to build your very own Todo Web API using controllers and file storage with .NET 8 and C#! 

## Table of Contents
- [Necessary tools](#necessary-tools)
- [Exploring Templates](#exploring-templates)
- [Creating Your Project](#creating-your-project)
- [Building Your Todo Web API](#building-your-todo-web-api)
  - [Setting Up Storage](#setting-up-storage)
  - [Creating Controllers and Services](#creating-controllers-and-services)
- [Write tests](#write-tests)
- [How To](#how-to)
  - [Add a new project via Solution Explorer](#add-a-new-project-via-solution-explorer)
  - [Add Nuget packages](#add-nuget-packages)
- [Knowledge land](#knowledge-land)
  - [Entity](#entity)
  - [Value object](#value-object)
  - [Inversion of Control](#inversion-of-control)
  - [DTO](#dto)

## Necessary tools 
- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) VS Code extension
- The [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- This awesome repository 

## Exploring Templates

Before diving headfirst into the coding abyss, let's take a moment to appreciate the wonders of technology and create a folder named `server` and run the following command in your terminal:
```bash
dotnet new list
```
*Brace yourself for a list of templates that will make you feel like a kid in a candy store. From web APIs to console apps, the possibilities are endless.*

## Creating Your Project

*Now that you've narrowed down your choices (hopefully without too much existential crisis), it's time to create your Todo Web API project.*

Execute the following commands in your terminal:

```bash
dotnet new webapi -n Todo.API  --use-controllers
dotnet new sln
dotnet sln add ./Todo.API/Todo.API.csproj
```
*Once the command finishes its magic incantations, you'll find yourself staring at a brand new project folder ready to be molded into greatness.*

## Building Your Todo Web API

### Setting Up Storage

*Ah, the joy of file storage—where your data can roam free like a herd of wild unicorns grazing in the cloud (or in this case, on your local machine). Let's set up our file storage system to keep track of those precious todo items.*

Check [Add a new project via Solution Explorer](#add-a-new-project-via-solution-explorer) and add a new `Class Library` project of name `Todo.Storage`

- In this project we need to define the `ITodoRepository` and `Todo` model.


Check [Add a new project via Solution Explorer](#add-a-new-project-via-solution-explorer) and add a new `Class Library` project of name `Todo.FileSystem`

- In this project we need to define the `TodoFileRepository`.


### Creating Controllers and Services

*With file storage in place, it's time to breathe life into your API by creating controllers. These magical creatures will handle incoming requests, perform the necessary sorcery (a.k.a. business logic), and conjure up delightful responses for your clients. Whether it's adding a new todo item or fetching the entire list, controllers are the guardians of your API's realm.*

Coming back to our `Todo.API` project, we should create our `TodoController`, `TodoService` and `ITodoService`.

The flow is: 
```bash 
client -> TodoController -> ITodoService -> ITodoRepository
```

## Write tests

*No journey is complete without a bit of testing. Fire up your favorite API testing tool (or curl commands if you're feeling nostalgic) and put your Todo Web API through its paces. Remember, testing isn't just about finding bugs—it's also an opportunity to appreciate the beauty of your creation and bask in the glory of a job well done.*

 - Add a new xUnit project via Solution Explorer
 - add package for running tests https://www.nuget.org/packages/xunit.runner.visualstudio 
 - package for mocking https://www.nuget.org/packages/Moq


## How to

### Add a new project via Solution Explorer

- Go to Solution Explorer
- Click on Add Project icon
- Select your desired template
- Give it a name

### Add Nuget packages

  - https://www.nuget.org/packages

## Knowledge land

### Entity:

An Entity represents a distinct object with a unique identity, typically persisted in a database. In the context of a TODO web API, examples could include tasks, users, or projects. Entities usually have a lifespan beyond a single request and encapsulate both data and behavior.

### Value Object:

A Value Object is an immutable object that represents a descriptive aspect of the domain with no conceptual identity. Unlike entities, value objects are defined by their attributes rather than their identity. In a TODO web API, a due date or task priority could be modeled as value objects.

### Inversion of Control:

Inversion of Control is a design principle where the control of flow is inverted compared to traditional programming. Instead of the application controlling the flow of program execution, IoC delegates this control to external frameworks or components. In .NET, IoC containers are commonly used to manage dependencies and promote loose coupling between components.

### DTO:

A DTO is a design pattern used to transfer data between software application subsystems. DTOs are typically simple data structures that contain only fields and no business logic. They facilitate the transfer of data between different layers of an application, such as between a controller and a service in a TODO web API, helping to decouple components and improve maintainability.

![rest-api](https://gist.github.com/assets/17832522/69fafa6d-0b13-4152-b608-a0db0aeecb17.png)
