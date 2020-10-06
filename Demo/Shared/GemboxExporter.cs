using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GemBox.Document;
using GemBox.Document.MailMerging;

namespace Demo.Shared
{
    public class GemboxExporter : IReportExporter
    {
        public GemboxExporter(string context, IEnumerable<string> extensions)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));

            var assembly = Assembly.GetExecutingAssembly();
            var folder = new DirectoryInfo(Path.GetDirectoryName(assembly.Location));
            if (!folder.Exists)
                throw new DirectoryNotFoundException(folder.FullName);

            Template = new FileInfo(Path.Combine(folder.FullName,  $"{context}Template.docx"));
            if (!Template.Exists)
                throw new FileLoadException(Template.FullName);

            Outputs = from extension in extensions
                      let name = $"{context}Output.{extension}"
                      let output = new FileInfo(Path.Combine(folder.FullName,  name))
                      select output;
        }

        protected string Context { get; }

        protected FileInfo Template { get; }

        protected IEnumerable<FileInfo> Outputs { get; }

        public void Export<T>(T data) where T : IReportData
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            ComponentInfo.FreeLimitReached += (sender, e) =>
            {
                e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;
            };

            var options = MailMergeClearOptions.RemoveEmptyRanges
                | MailMergeClearOptions.RemoveEmptyTableRows;

            var document = DocumentModel.Load(Template.FullName);
            document.MailMerge.RangeStartPrefix = "#";
            document.MailMerge.RangeEndPrefix = "/";
            document.MailMerge.ClearOptions = options;
            
            // Map merge fields with prefix to data source without prefix.
            // E.g. "Html:MyName" field's name to "MyName" data source name.
            foreach (string fieldName in document.MailMerge.GetMergeFieldNames())
            {
                int index = fieldName.IndexOf(':');
                if (index > 0 && !document.MailMerge.FieldMappings.ContainsKey(fieldName))
                    document.MailMerge.FieldMappings.Add(fieldName, fieldName.Substring(index + 1));
            }

            // Customize mail merge to support our custom prefixes.
            document.MailMerge.FieldMerging += (sender, e) =>
            {
                if (!e.IsValueFound)
                    return;

                bool customImport = true;

                if (e.FieldName.StartsWith("Html:"))
                    e.Field.Content.End.LoadText((string)e.Value, LoadOptions.HtmlDefault);
                else if (e.FieldName.StartsWith("Rtf:"))
                    e.Field.Content.End.LoadText((string)e.Value, LoadOptions.RtfDefault);
                else if (e.FieldName.StartsWith("Docx:"))
                    e.Field.Content.End.InsertRange(DocumentModel.Load((string)e.Value).Sections[0].Blocks.Content);
                else
                    customImport = false;


                if (customImport)
                {
                    // Remove the default import.
                    e.Inline = null;
                    if (e.Field.ParentCollection.Count == 1)
                        e.Field.Parent.Content.Delete();
                }
            };

            document.MailMerge.Execute(data);

            Console.WriteLine($"# {Context}");
            Console.WriteLine("Template");
            Console.WriteLine(Template.FullName);
            Console.WriteLine();

            Console.WriteLine("Outputs");
            foreach (var output in Outputs)
            {
                document.Save(output.FullName);
                Console.WriteLine(output.FullName);
                Console.WriteLine();
            }
        }
    }
}