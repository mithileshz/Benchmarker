//using BenchmarkDotNet.Running;
//using Benchmarker.Benchmarks;
//using Benchmarker.Core;
//using Microsoft.Azure.Cosmos;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

using BenchmarkDotNet.Running;
using Benchmarker.Benchmarks;

var results = BenchmarkRunner.Run<EmptyString>();

//var config = GetConfigFromEnvironmentVariables();

//Database database = await GetDatabase(config);

//List<BenchmarkDetail> benchmarksInTheCodebase = GetAllBenchmarkDetailsInCodebaseViaReflection();

//List<BenchmarkDetail> benchmarksFromDb = new List<BenchmarkDetail>();// await GetAllBenchmarkDetailsFromDb(benchmarksInTheCodebase, config, database);

//foreach(BenchmarkDetail implementedBenchmark in benchmarksInTheCodebase)
//{
//    BenchmarkDetail? benchmarkDb = benchmarksFromDb.FirstOrDefault(benchmark => benchmark.Id == implementedBenchmark.Id);

//    if (benchmarkDb == null)
//    {
//        await RunBenchmarkAndSave(implementedBenchmark, database);
//    } 
//    else
//    {
//        if (IsBenchmarkUpdated(implementedBenchmark, benchmarkDb))
//        {
//            await RunBenchmarkAndSave(implementedBenchmark, database);
//        }
//        else
//        {
//            continue;
//        }
//    }
//}

//async Task RunBenchmarkAndSave(BenchmarkDetail implementedBenchmark, Database database)
//{
//    var results = BenchmarkRunner.Run(implementedBenchmark.Type);

//    if (results == null)
//        throw new InvalidProgramException($"{implementedBenchmark.FullName} benchmark ran incorrectly. There were no results");

//    Container benchmarkDetailsContainer = await database.CreateContainerIfNotExistsAsync(config.AzureCosmosDB.BenchmarkDetailsContainer, "/id");

//    var latestVersion = ((VersionAttribute)implementedBenchmark.Type.GetCustomAttributes(false).First(attr => attr.GetType().Equals(typeof(VersionAttribute)))).Version;

//    try
//    {
//        ItemResponse<BenchmarkDetail> fullBenchmarkDetail = await benchmarkDetailsContainer.ReadItemAsync<BenchmarkDetail>(implementedBenchmark.Id, new PartitionKey(implementedBenchmark.Id));

//        fullBenchmarkDetail.Resource.LastRunVersion = latestVersion;
//        fullBenchmarkDetail.Resource.Results.Add(new BenchmarkSummary
//        {
//            Version = latestVersion,
//            Summary = System.IO.File.ReadAllText(results.ResultsDirectoryPath)
//        });

//        Console.WriteLine(results.ResultsDirectoryPath);

//        await benchmarkDetailsContainer.UpsertItemAsync(fullBenchmarkDetail.Resource, new PartitionKey(fullBenchmarkDetail.Resource.Id));
//    }
//    catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
//    {
//        var newBenchmarkDetail = new BenchmarkDetail
//        {
//            Id = implementedBenchmark.Id,
//            Name = implementedBenchmark.Name,
//            FullName = implementedBenchmark.FullName,
//            Type = implementedBenchmark.Type,
//            LastRunVersion = latestVersion,
//            Results = new List<BenchmarkSummary>
//            {
//                new BenchmarkSummary
//                {
//                    Version = latestVersion,
//                    Summary = System.IO.File.ReadAllText(results.ResultsDirectoryPath)
//                }
//            }
//        };

//        Console.WriteLine(results.ResultsDirectoryPath);

//        await benchmarkDetailsContainer.CreateItemAsync(newBenchmarkDetail, new PartitionKey(newBenchmarkDetail.Id));
//    }
//}

//bool IsBenchmarkUpdated(BenchmarkDetail implementedBenchmark, BenchmarkDetail benchmarkDb)
//{
//    return implementedBenchmark.LastRunVersion != benchmarkDb.LastRunVersion;
//}

//Config GetConfigFromEnvironmentVariables()
//{
//    var configJson = Environment.GetEnvironmentVariable("BenchmarkerConfig", EnvironmentVariableTarget.User);

//    if (configJson == null)
//        throw new InvalidProgramException("BenchmarkerConfig environment variable not set.");

//    var config = System.Text.Json.JsonSerializer.Deserialize<Config>(configJson);

//    if (config == null)
//        throw new ArgumentNullException(nameof(config));

//    return config;
//}

//async Task<Database> GetDatabase(Config config)
//{
//    var cosmos = new CosmosClient(config.AzureCosmosDB.Uri, config.AzureCosmosDB.PrimaryKey);

//    Database database = await cosmos.CreateDatabaseIfNotExistsAsync(config.AzureCosmosDB.DatabaseName);

//    return database;
//}

//async Task<List<BenchmarkDetail>> GetAllBenchmarkDetailsFromDb(List<BenchmarkDetail> implementedBenchmarks, Config config, Database database)
//{
//    Container benchmarkDetailsContainer = await database.CreateContainerIfNotExistsAsync(config.AzureCosmosDB.BenchmarkDetailsContainer, "/id");

//    var sqlQuery = "SELECT c.id, c.Name, c.FullName, c.LastRunVersion FROM c";

//    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

//    FeedIterator<BenchmarkDetail> queryResultSetIterator = benchmarkDetailsContainer.GetItemQueryIterator<BenchmarkDetail>(queryDefinition);

//    List<BenchmarkDetail> benchmarkHeaders = new List<BenchmarkDetail>();

//    while (queryResultSetIterator.HasMoreResults)
//    {
//        FeedResponse<BenchmarkDetail> currentResultSet = await queryResultSetIterator.ReadNextAsync();

//        foreach (var benchmarkHeader in currentResultSet)
//        {
//            benchmarkHeaders.Add(benchmarkHeader);
//        }
//    }

//    return benchmarkHeaders;
//}

//List<BenchmarkDetail> GetAllBenchmarkDetailsInCodebaseViaReflection()
//{
//    Type referenceTypeForReflection = typeof(IReflectionReferenceInterface);

//    List<Type> benchmarks = referenceTypeForReflection.Assembly.GetTypes().Where(type => type.IsClass && type.GetCustomAttributes(false).Any(attr => attr.GetType().Equals(typeof(VersionAttribute)))).ToList();

//    List<BenchmarkDetail> benchmarkHeaders = new List<BenchmarkDetail>();

//    foreach(Type benchmarkType in benchmarks)
//    {
//        benchmarkHeaders.Add(new BenchmarkDetail
//        {
//            Id = GetGuid(benchmarkType.Name).ToString(),
//            Name = benchmarkType.Name,
//            FullName = benchmarkType.FullName,
//            LastRunVersion = ((VersionAttribute)benchmarkType.GetCustomAttributes(false).First(attr => attr.GetType().Equals(typeof(VersionAttribute)))).Version,
//            Type = benchmarkType
//        });
//    }

//    return benchmarkHeaders;
//}

//Guid GetGuid(string input)
//{
//    using (MD5 md5 = MD5.Create())
//    {
//        byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
//        return new Guid(hash);
//    }
//}

//class BenchmarkDetail
//{
//    [JsonProperty(PropertyName = "id")]
//    public string Id { get; set; }

//    public string? Name { get; set; }

//    public string? FullName { get; set; }

//    public int LastRunVersion { get; set; }

//    public Type? Type { get; set; }

//    public List<BenchmarkSummary>? Results { get; set; }
//}

//class BenchmarkSummary
//{
//    public int Version { get; set; }

//    public string? Summary { get; set; }
//}