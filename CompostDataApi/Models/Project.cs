using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompostDataApi.Models
{
    public class Project
    {
        public Project(Guid id, DateTime startDate)
        {
            Id = id;
            StartDate = startDate;
        }

        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
    }
}
