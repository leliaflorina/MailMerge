using Demo.Models;
using Demo.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class DemoProvider : IReportProvider<ReportData>
    {
        public ReportData Build(string title)
        {
            var notes = new StringModel[3];
            notes[0] = new StringModel { Value = "<ul><li> This is a list </li><li> This is a list </li> </ul> " };
            notes[1] = new StringModel { Value = "<h1>Hello World</h1>" };
            notes[2] = new StringModel { Value = "<strong>This text is important!</strong>" };

            return new ReportData
            {
                Title = title,
                Objective = "<h4>Heading 4</h4><h5> Heading 5 </h5><h6> Heading 6 </h6>",
                Notes = notes,
                Stamp = DateTime.Now,
            };
        }
    }
}
