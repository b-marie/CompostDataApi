using CompostDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompostDataApi.Services
{
    public class ProjectService
    {
        CosmosDbUtil _cosmosDbUtil;
        private readonly string projectDevice = "mainDevice";

        public ProjectService(CosmosDbUtil cosmosDbUtil)
        {
            _cosmosDbUtil = cosmosDbUtil;
        }

        public async Task<Project> GetProject(Guid id)
        {
            DateTime startDate = DateTime.UtcNow;
            startDate.AddDays(-2);
            return new Project(Guid.NewGuid(), startDate);
        }

        public async Task<IEnumerable<CompostData>> GetCompostData(int results)
        {
            return await _cosmosDbUtil.GetItemsAsync(results);

        }

        private List<CompostData> GenerateMockCompostData()
        {
            List<CompostData> compostDataList = new List<CompostData>();
            DateTime now = DateTime.UtcNow;
            
            CompostData data1 = new CompostData(Guid.NewGuid(), now.AddMinutes(-1).ToString(), 60.0f, 55f, 40f);
            CompostData data2 = new CompostData(Guid.NewGuid(), now.AddMinutes(-2).ToString(), 59.9f, 54f, 41f);
            CompostData data3 = new CompostData(Guid.NewGuid(), now.AddMinutes(-3).ToString(), 59.8f, 54f, 41f);
            CompostData data4 = new CompostData(Guid.NewGuid(), now.AddMinutes(-4).ToString(), 59.7f, 53f, 42f);
            CompostData data5 = new CompostData(Guid.NewGuid(), now.AddMinutes(-5).ToString(), 59.8f, 54f, 41f);
            compostDataList.Add(data1);
            compostDataList.Add(data2);
            compostDataList.Add(data3);
            compostDataList.Add(data4);
            compostDataList.Add(data5);

            return compostDataList;  
        }
    }
}
