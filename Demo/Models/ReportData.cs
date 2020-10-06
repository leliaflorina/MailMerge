using Demo.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{

    public class ReportData : IReportData
    {
        public string Title { get; set; }

        public DateTime Stamp { get; set; }

        public string Objective { get; set; }

        public StringModel[] Notes { get; set; }
    }
}
