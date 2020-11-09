using System;
using System.Collections.Generic;

namespace KAB_SQL_API.Models
{
    public partial class SourceSystem
    {
        public int SourceSystemId { get; set; }
        public string SourceSystem1 { get; set; }
        public string SourceDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Countryid { get; set; }
        public string LocalErp { get; set; }
        public string Erplegalentity { get; set; }
    }
}
