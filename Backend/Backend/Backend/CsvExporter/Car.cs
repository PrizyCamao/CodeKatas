using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CsvExporter
{
    public class Car
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Car(string name, string description) 
        {
            Name = name;
            Description = description;
        }
    }
}
