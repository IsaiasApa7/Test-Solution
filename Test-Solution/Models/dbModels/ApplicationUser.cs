using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test_Solution.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Users = new HashSet<Inspection>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pass { get; set; }

        [InverseProperty(nameof(Inspection.IdUserNavigation))]
        public virtual ICollection<Inspection> Users { get; set; }


    }
}
