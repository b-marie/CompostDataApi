using CompostDataApi.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompostDataApi.Services
{
    public class CosmosDbUtil
    {
        private Container _container;
        private CosmosClient dbClient;
        private readonly string databaseName = "ToDoList";
        private readonly string containerName = "CompostDeviceData";

        public CosmosDbUtil()
        {
            dbClient = new CosmosClient(Environment.GetEnvironmentVariable("EndpointUrl"), Environment.GetEnvironmentVariable("PrimaryKey"));
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<CompostData>> GetItemsAsync(int results)
        {
            var sqlQueryText = $"SELECT TOP {results} * FROM c ORDER BY c.timeStamp DESC";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<CompostData> queryResultSetIterator = _container.GetItemQueryIterator<CompostData>(queryDefinition);

            List<CompostData> data = new List<CompostData>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<CompostData> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (CompostData compostData in currentResultSet)
                {
                    data.Add(compostData);
                    Console.WriteLine("\tRead {0}\n", compostData);
                }
            }

            return data;
        }
    }
}
