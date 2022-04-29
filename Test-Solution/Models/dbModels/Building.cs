using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Test_Solution.Models.dbModels
{
    public partial class Building
    {
        public Building()
        {
            InspectionTypes = new HashSet<InspectionType>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string BuildingName { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [InverseProperty(nameof(InspectionType.Building))]
        public virtual ICollection<InspectionType> InspectionTypes { get; set; }
    }
}
