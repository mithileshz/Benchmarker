using BenchmarkDotNet.Running;
using Benchmarker.Benchmarks;
using Microsoft.Azure.Cosmos;
using System;

var configJson = Environment.GetEnvironmentVariable("BenchmarkerConfig");

if (configJson == null)
    throw new InvalidProgramException("BenchmarkerConfig environment variable not set. One word.");

var config = System.Text.Json.JsonSerializer.Deserialize<Config>(configJson);

var cosmos = new CosmosClient(config.AzureCosmosDB.ConnectionString);

var database = cosmos.GetDatabase(config.AzureCosmosDB.DatabaseName);

var container = database.GetContainer(config.EnvironmentName);

await container.CreateItemAsync(new
{
    id = Guid.NewGuid(),
});

BenchmarkRunner.Run<MethodGroups>();

class Config
{
    public string EnvironmentName { get; set; }

    public AzureCosmosDB AzureCosmosDB { get; set; }

    public Config(string environmentName, AzureCosmosDB azureCosmosDB)
    {
        EnvironmentName = environmentName;
        AzureCosmosDB = azureCosmosDB;
    }   
}

class AzureCosmosDB
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public AzureCosmosDB(string connectionString, string databaseName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
    }   
}