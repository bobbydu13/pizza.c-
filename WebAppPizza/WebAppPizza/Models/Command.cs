using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPizza.Models
{
    public class Command
    {   
        [Key] // clef primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // generation de l'auto incrementation

        public int IDCommand { get; set; }

        public DateTime CommandDate { get; set; }

        public decimal Total { get; set; }

        public ICollection<DetailCommand> DetailCommands { get; set; }


        [NotMapped]
        public String Description { get; set; }


        public Command()
        {
            DetailCommands = new HashSet<DetailCommand>();// initialiser une collection ordonnée
        }
    }
}