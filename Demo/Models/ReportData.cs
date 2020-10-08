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
        
        public GroupModel[] Records { get; set; }

        public dynamic RecordsWrap => new { Records };
    }
    public class GroupModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Notes { get; set; }
    }
}
