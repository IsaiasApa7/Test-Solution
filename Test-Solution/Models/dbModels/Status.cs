using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Test_Solution.Models.dbModels
{
    public partial class Status
    {
        public Status()
        {
            Inspections = new HashSet<Inspection>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(Inspection.Status))]
        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
