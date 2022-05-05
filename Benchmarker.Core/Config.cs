namespace Benchmarker.Core
{
    public class Config
    {
        public Config(string environmentName, AzureCosmosDB azureCosmosDB)
        {
            EnvironmentName = environmentName;
            AzureCosmosDB = azureCosmosDB;
        }

        public string EnvironmentName { get; set; }

        public AzureCosmosDB AzureCosmosDB { get; set; }
    }

    public class AzureCosmosDB
    {
        public AzureCosmosDB(string uri, string primaryKey, string databaseName, string benchmarkDetailsContainer)
        {
            Uri = uri;
            PrimaryKey = primaryKey;
            DatabaseName = databaseName;
            BenchmarkDetailsContainer = benchmarkDetailsContainer;
        }

        public string Uri { get; set; }

        public string PrimaryKey { get; set; }

        public string DatabaseName { get; set; }

        public string BenchmarkDetailsContainer { get; set; }

        
    }
}
