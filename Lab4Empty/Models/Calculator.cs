
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;


namespace Lab4Empty.Models
{
    public class Calculator
    {
        [Required(ErrorMessage = "Первая переменная необходима")]
        [StringLength(3, MinimumLength =2, ErrorMessage ="Длина от 2 до 3")]
        public int First{get; set;}
        public int Second{get; set;}
        public float Result {get; set;}
        public string Operand {set;get; }

        public Calculator LastResult {get; set;}
    }
}
