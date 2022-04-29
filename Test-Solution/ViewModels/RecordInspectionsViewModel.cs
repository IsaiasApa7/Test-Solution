using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test_Solution.ViewModels
{
    public class RecordInspectionsViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Description:")]
        public string Description { get; set; }

        public List<SelectListItem> inspectiontype { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Type of inspection:")]
        public int InspectionType { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Status:")]
        public int StatusID { get; set; }
        public List<SelectListItem> TypeStatus { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Inspector:")]
        public int UserID { get; set; }
        public List<SelectListItem> Users { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        [DisplayName("Date:")]
        public DateTime Date { get; set; }


    }
}
