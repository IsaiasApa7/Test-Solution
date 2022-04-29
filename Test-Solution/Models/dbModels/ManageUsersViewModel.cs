using System.Collections.Generic;
namespace Test_Solution.Models.dbModels
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Supervisor { get; set; }

        public ApplicationUser[] Inspector { get; set; }
    }
}
