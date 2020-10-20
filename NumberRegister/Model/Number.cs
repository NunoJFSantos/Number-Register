using System.ComponentModel.DataAnnotations;

namespace NumberRegister.Model
{
    public class Number
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public double InsertedNum { get; set; }
        
    }
}