//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminModuleEntitiy.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AD_CompanyProfile
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int BusinessTypeId { get; set; }
        public int BusinessNatureId { get; set; }
        public string BIN { get; set; }
        public byte[] TIN { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Phone { get; set; }
        public string ContactPersion { get; set; }
        public string IncorporationNumber { get; set; }
        public string Remarks { get; set; }
        public int CreatorId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int ModifierId { get; set; }
        public System.DateTime ModificationDate { get; set; }
    }
}