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
    
    public partial class MedicalCondition
    {
        public int PatientId { get; set; }
        public string Diagnose { get; set; }
        public string MedicalHistory { get; set; }
        public string Symptom { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}