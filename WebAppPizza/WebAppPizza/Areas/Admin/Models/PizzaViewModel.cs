using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPizza.Areas.Admin.Models
{
    public class PizzaViewModel
    {   
        
        public int IDPizza { get; set; }

        [Required]//attribut de validation,  vaut pour la propriete de dessous uniquement!!!
        [RegularExpression(@"^[A-Z-0-9]{1}[\ 'a-z]{1,34}$")]
        [Display(Name = "Nom de la pizza")]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z]{1}[\- .,'çéèàa-zA-Z]+",ErrorMessage ="Ne correspond pas au format attendu")]
        [MaxLength(300)]
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode =false, DataFormatString ="{0:C2}")]
        [Display(Name = "Prix H.T.")]
        public decimal PriceHT { get; set; }

        public string Image { get; set; }

        public IFormFile UploadImage { get; set; }

        public bool AddNewPizza { get; set; } = false;

    }
}
