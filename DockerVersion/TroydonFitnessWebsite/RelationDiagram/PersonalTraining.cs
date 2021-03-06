//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RelationDiagram
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonalTraining
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonalTraining()
        {
            this.Carts = new HashSet<Cart>();
            this.Diets = new HashSet<Diet>();
            this.TrainingRoutines = new HashSet<TrainingRoutine>();
        }
    
        public int PersonalTrainingID { get; set; }
        public int ProductID { get; set; }
        public string Description { get; set; }
        public string PersonalTrainingName { get; set; }
        public int LengthOfRoutine { get; set; }
        public int PTSessionType { get; set; }
        public int ExperienceLevel { get; set; }
        public byte[] PtProductPicture { get; set; }
        public bool IsFeatured { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diet> Diets { get; set; }
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingRoutine> TrainingRoutines { get; set; }
    }
}
