namespace CsvExporter
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
