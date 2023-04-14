using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CsvExporter
{
    public class Exporter
    {
        public string ExportToCsv(string[] headers, string[][] rows)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(";", headers));

            for(int i = 0; i < rows.GetLength(0); i++) 
            {
                sb.AppendLine(string.Join(";", rows[i]));
            }

            return sb.ToString();
        }

        public string ExportToCsv(Car[] cars)
        {
            StringBuilder sb = new StringBuilder();
            var type = cars[0].GetType();
            var properties = type.GetProperties();
            sb.AppendLine(string.Join(";", properties.Select(p => p.Name)));

            foreach(var car in cars)
            {
                sb.AppendLine(string.Join(";", properties.Select(p => p.GetValue(car))));
            }

            return sb.ToString();
        }

        public IEnumerable<string> ExportToCsv(IEnumerable<Car> cars)
        {
            var type = cars.First().GetType();
            var properties = type.GetProperties();
            yield return string.Join(";", properties.Select(p => p.Name));

            foreach (var car in cars)
            {
                yield return string.Join(";", properties.Select(p => p.GetValue(car)));
            }
        }
    }
}
