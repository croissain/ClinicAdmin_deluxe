//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicAdmin.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<int> TotalMedicines { get; set; }
        public Nullable<int> TotalPatients { get; set; }
        public Nullable<int> TotalInvoice { get; set; }
        public Nullable<double> SumProfit { get; set; }
        public Nullable<double> ProfitInDay { get; set; }
        public Nullable<int> PatientInDay { get; set; }
        public string ReportPerson { get; set; }
        public string Descript { get; set; }
        public string Purpose { get; set; }
    }
}