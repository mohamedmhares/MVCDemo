using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Games : BaseEntity
    {
      
        
        [Required] [MaxLength (2500)]
        public string Description { get; set; }
        
        [Required] [MaxLength (500)]
        public string Cover { get; set; } =string.Empty;


        public int CategoryID { get; set; }

        public Category Category { get; set; } = default!;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();




    }
}
