using Backend.CsvExporter;
using Xunit;

namespace CsvExporterTest
{
    public class CsvExporterTests
    {
        [Fact]
        public void Test1()
        {
            Exporter exporter = new Exporter();

            var headers = Enumerable.Range(0, 10).Select(i => "Spalte" + i.ToString()).ToArray();
            var rows = Enumerable.Range(0, 1000000).Select(row =>
            Enumerable.Range(0, 10).Select(col => $"Row{row},Col{col}").ToArray()
            ).ToArray();

            var result = exporter.ExportToCsv(headers, rows);
            File.WriteAllText("output\\test1.csv", result);
        }

        [Fact]
        public void Test2()
        {
            Exporter exporter = new Exporter();

            var cars = CreateCars().ToArray();

            var result = exporter.ExportToCsv(cars);
            File.WriteAllText("output\\test2.csv", result);
        }

        [Fact]
        public void Test3()
        {
            Exporter exporter = new Exporter();

            var cars = CreateCars();

            var result = exporter.ExportToCsv(cars);
            File.WriteAllLines("output\\test3.csv", result);
        }

        private IEnumerable<Car> CreateCars()
        {
            return Enumerable.Range(0, 1000000).Select(x => new Car(
                    x++.ToString(),
                    x.ToString()
                ));
        }
    }
}