using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test_Solution.ViewModels
{
    public class RecordInspectionTypeViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Inspection Type Name :")]
        public string TypeName { get; set; }

        public List<SelectListItem> Buildings { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Building:")]
        public int BuildingID { get; set; }
    }
}
