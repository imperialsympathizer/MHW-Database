//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArmorDBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SetBonus
    {
        public long BonusID { get; set; }
        public long SetID { get; set; }
        public long SkillID { get; set; }
        public decimal NumRequired { get; set; }
    
        public virtual Skill Skill { get; set; }
        public virtual Set Set { get; set; }
    }
}
