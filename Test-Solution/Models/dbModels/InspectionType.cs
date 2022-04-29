using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Test_Solution.Models.dbModels
{
    public partial class InspectionType
    {
        public InspectionType()
        {
            Inspections = new HashSet<Inspection>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }
        [Column("BuildingID")]
        public int BuildingId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        [InverseProperty("InspectionTypes")]
        public virtual Building Building { get; set; }
        [InverseProperty(nameof(Inspection.InspectionType))]
        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
