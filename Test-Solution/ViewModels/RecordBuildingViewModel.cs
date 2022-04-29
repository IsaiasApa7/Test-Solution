using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test_Solution.ViewModels
{
    public class RecordBuildingViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Building Name:")]
        public string BuildingName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Address:")]
        public string Address { get; set; }
    }
}
