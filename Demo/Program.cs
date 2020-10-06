using Demo.Shared;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Run(new DemoProvider(), "Demo");
            
        }

        public static void Run<T>(IReportProvider<T> provider, string feature)
            where T : IReportData
        {
            var data = provider.Build(title: feature);
            var extensions = new[] { "pdf", "docx" };
            var exporter = new GemboxExporter(context: feature, extensions);
            exporter.Export(data);
        }
    }
}
