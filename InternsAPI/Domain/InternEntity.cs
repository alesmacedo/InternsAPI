using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternsAPI.Domain
{
    [Table(name:"Interns")]
    public class InternEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]   //Indica que essa coluna não pode ser nula e MaxLength indica tamanho máximo da string
        public string Name { get; set; }
        [Range(16, int.MaxValue)]
        public int Age { get; set; }
        [Required]
        public string Squad { get; set; }
        [Required]
        public string Leader { get; set; }
    }
}
