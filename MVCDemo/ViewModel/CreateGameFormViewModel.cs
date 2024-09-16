using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDemo.Attrbuites;
using MVCDemo.Settings;
using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace MVCDemo.ViewModel
{
    public class CreateGameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]

        public List<int> SelectedDevices { get; set; } = default!;

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(2500)]
        public string Description { get; set; }

        //Validate Extentions  and Size
        [AllowedExtensionsAttrbuite(FileSettings.AllowedExtentions), 
            MaxFileSize(FileSettings.MaxFileSizeInByte)]
        public IFormFile Cover { get; set; } = default! ;


    }
}

