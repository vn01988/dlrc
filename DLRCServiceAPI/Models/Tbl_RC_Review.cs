//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DLRCServiceAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_RC_Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vehicle_Registration_Number { get; set; }
        public string Penalty { get; set; }
        public string Review_Date { get; set; }
        public string Officer_id { get; set; }
        public string Receipt_Number { get; set; }
        public string Backend_Update_Flag { get; set; }
        public string Terminal_Id { get; set; }
    }
}
