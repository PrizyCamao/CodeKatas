using CsvExporter;
using System.Diagnostics;
using Xunit.Abstractions;
using Csv = CsvExporter.CsvExporter;

namespace CsvExporterTests
{
    public class CsvExporterTests
    {
        private readonly ITestOutputHelper output;

        public CsvExporterTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            var exporter = new Csv();
            
            var headers = Enumerable.Range(0, 10).Select(i => "Spalte" + i.ToString()).ToArray();
            var rows = Enumerable.Range(0, 1000000).Select(row => 
                Enumerable.Range(0, 10).Select(col => $"R{row},C{col}").ToArray()
            ).ToArray();

            var sw = new Stopwatch();
            sw.Start();
            var result = exporter.ExportToCsv(headers, rows);
            sw.Stop();

            output.WriteLine(sw.ElapsedMilliseconds.ToString());
            File.WriteAllText("test.csv", result);
        }

        [Fact]
        public void Reflection()
        {
            var exporter = new Csv();

            var rows = Enumerable.Range(0, 1000000).Select(row =>
                new Dto { 
                    Prop1 = $"R{row},C1",
                    Prop2 = $"R{row},C2",
                    Prop3 = $"R{row},C3",
                    Prop4 = $"R{row},C4",
                    Prop5 = $"R{row},C5",
                    Prop6 = $"R{row},C6",
                    Prop7 = $"R{row},C7",
                    Prop8 = $"R{row},C8",
                    Prop9 = $"R{row},C9",
                    Prop10 = $"R{row},C10"
                }
            ).ToArray();

            var sw = new Stopwatch();
            sw.Start();
            var result = exporter.ExportToCsv(rows);
            sw.Stop();

            output.WriteLine(sw.ElapsedMilliseconds.ToString());
            File.AppendAllText("test.csv", result);
        }

        [Fact]
        public void TestEnumerable()
        {
            var exporter = new Csv();

            var rows = Enumerable.Range(0, 1000000).Select(row =>
                new Dto
                {
                    Prop1 = $"R{row},C1",
                    Prop2 = $"R{row},C2",
                    Prop3 = $"R{row},C3",
                    Prop4 = $"R{row},C4",
                    Prop5 = $"R{row},C5",
                    Prop6 = $"R{row},C6",
                    Prop7 = $"R{row},C7",
                    Prop8 = $"R{row},C8",
                    Prop9 = $"R{row},C9",
                    Prop10 = $"R{row},C10"
                }
            );

            var sw = new Stopwatch();
            sw.Start();
            var result = exporter.ExportToCsvEnumerable(rows);
            sw.Stop();

            output.WriteLine(sw.ElapsedMilliseconds.ToString());
            File.WriteAllLines("test.csv", result);
        }

        [Fact]
        public void TestStream()
        {
            var exporter = new Csv();

            var rows = Enumerable.Range(0, 1000000).Select(row =>
                new Dto
                {
                    Prop1 = $"R{row},C1",
                    Prop2 = $"R{row},C2",
                    Prop3 = $"R{row},C3",
                    Prop4 = $"R{row},C4",
                    Prop5 = $"R{row},C5",
                    Prop6 = $"R{row},C6",
                    Prop7 = $"R{row},C7",
                    Prop8 = $"R{row},C8",
                    Prop9 = $"R{row},C9",
                    Prop10 = $"R{row},C10"
                }
            );

            var sw = new Stopwatch();
            sw.Start();
            var result = exporter.ExportToCsvStream(rows);
            sw.Stop();

            output.WriteLine(sw.ElapsedMilliseconds.ToString());
            using var file = File.Create("test.csv");
            result.CopyTo(file);
            result.Close();
            file.Close();
        }
    }
}