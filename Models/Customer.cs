using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z]+[ .'-]?)+([ ,]?)+[a-zA-Z]+.?$", ErrorMessage = "Please enter a valid name")]
        public string Name {get; set;}

        public int Score { get; set; }
    }
}
