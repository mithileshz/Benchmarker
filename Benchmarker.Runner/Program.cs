using BenchmarkDotNet.Running;
using Benchmarker.Benchmarks;
using Benchmarker.Core;
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