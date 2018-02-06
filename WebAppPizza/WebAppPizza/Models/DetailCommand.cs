using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPizza.Models
{
    public class DetailCommand
    {   

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDDetailCommand { get; set; }

        public int IDPizza { get; set; }

        public int IDCommand { get; set; }

        public Pizza Pizza { get; set; }

        public Command Command { get; set; }

        
    }
}