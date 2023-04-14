using System.Text;

namespace CsvExporter
{
    public class CsvExporter
    {
        public string ExportToCsv(string[] headers, string[][] rows)
        {
            var csv = new StringBuilder(string.Join(";", headers));
            csv.AppendLine();
            foreach (var row in rows)
            {
                csv.AppendLine(string.Join(";", row));
            }
            return csv.ToString();
        }

        public string ExportToCsvDumb(string[] headers, string[][] rows)
        {
            var csv = string.Join(";", headers);
            csv += Environment.NewLine;
            foreach (var row in rows)
            {
                csv += string.Join(";", row);
                csv += Environment.NewLine;
            }
            return csv.ToString();
        }

        public string ExportToCsv(Dto[] dtos)
        {
            var props = typeof(Dto).GetProperties();
            var csv = new StringBuilder(string.Join(";", props.Select(p => p.Name)));
            csv.AppendLine();
            foreach (var dto in dtos)
            {
                csv.AppendLine(string.Join(";", props.Select(p => p.GetValue(dto))));
            }
            return csv.ToString();
        }

        public IEnumerable<string> ExportToCsvEnumerable(IEnumerable<Dto> dtos)
        {
            var props = typeof(Dto).GetProperties();
            yield return string.Join(";", props.Select(p => p.Name));
            foreach (var dto in dtos)
            {
                yield return string.Join(";", props.Select(p => p.GetValue(dto)));
            }
        }

        public Stream ExportToCsvStream(IEnumerable<Dto> dtos)
        {
            var props = typeof(Dto).GetProperties();
            var stream = new MemoryStream();
            stream.Write(Encoding.UTF8.GetBytes(string.Join(";", props.Select(p => p.Name)) + Environment.NewLine));
            foreach (var dto in dtos)
            {
                stream.Write(Encoding.UTF8.GetBytes(string.Join(";", props.Select(p => p.GetValue(dto))) + Environment.NewLine));
            }
            stream.Position = 0;
            return stream;
        }
    }
}