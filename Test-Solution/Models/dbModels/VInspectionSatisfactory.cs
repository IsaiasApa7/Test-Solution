using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Test_Solution.Models.dbModels
{
    [Keyless]
    public partial class VInspectionSatisfactory
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string BuildingName { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }
    }
}
