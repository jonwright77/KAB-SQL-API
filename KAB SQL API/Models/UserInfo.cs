using System;
using System.Collections.Generic;

namespace KAB_SQL_API.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
