using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Test_Solution.Models.dbModels
{
    public partial class Inspection
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("InspectionTypeID")]
        public int InspectionTypeId { get; set; }
        [Column("StatusID")]
        public int StatusId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(UserId))]

        [InverseProperty(nameof(ApplicationUser.Users))]
        public virtual ApplicationUser IdUserNavigation { get; set; }

        [ForeignKey(nameof(InspectionTypeId))]
        [InverseProperty("Inspections")]
        public virtual InspectionType InspectionType { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty("Inspections")]
        public virtual Status Status { get; set; }
    }
}
