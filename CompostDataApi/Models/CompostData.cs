using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompostDataApi.Models
{
    public class CompostData
    {
        public CompostData(Guid id, string timestamp, float temperature, float humidity, float moisture)
        {
            Id = id;
            Timestamp = timestamp;
            Temperature = temperature;
            Humidity = humidity;
            Moisture = moisture;
        }

        public Guid Id { get; set; }
        public string Timestamp { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Moisture { get; set; }
    }
}
