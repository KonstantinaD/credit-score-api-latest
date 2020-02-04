using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z]+[ .'-]?)+([ ,]?)+[a-zA-Z]+\.?$", ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }

        public int Score { get; set; }
    }
}
