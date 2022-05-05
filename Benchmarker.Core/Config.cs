using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarker.Core
{
    public class Config
    {
        public string EnvironmentName { get; set; }

        public AzureCosmosDB AzureCosmosDB { get; set; }

        public Config(string environmentName, AzureCosmosDB azureCosmosDB)
        {
            EnvironmentName = environmentName;
            AzureCosmosDB = azureCosmosDB;
        }
    }

    public class AzureCosmosDB
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public AzureCosmosDB(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }
    }
}
