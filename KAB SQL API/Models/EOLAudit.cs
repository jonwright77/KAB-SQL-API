using System;
using System.Collections.Generic;

namespace KAB_SQL_API.Models
{
    public partial class EOLAudit
    {
        public int EOLID { get; set; }
        public string SerialId { get; set; }
        public string ItemId { get; set; }
        public string SuspBuild { get; set; }
        public string HeightRiserBuild { get; set; }
        public string TrimBuild { get; set; }
        public string SlideRailsBuild { get; set; }
        public string UpperToSuspBuild { get; set; }
        public string ARestSBeltBuild { get; set; }
        public string TestPack { get; set; }


    }
}
