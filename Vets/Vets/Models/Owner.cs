using System.ComponentModel.DataAnnotations;

namespace Vets.Models
{
    /// <summary>
    /// describes the owner's data
    /// </summary>
    public class Owner
    {

        public Owner()
        {
            Animals = new HashSet<Animal>();
        }

        /// <summary>
        /// PK for the Owner
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Owner's name
        /// </summary>
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [StringLength(25, ErrorMessage = "O {0} não pode ter mais de 25 carateres")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        /// <summary>
        /// Owner's unique identification number
        /// </summary>
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter exatamente 9 números")]
        [Display(Name = "NIF")]
        public string NIF { get; set; }

        /// <summary>
        /// Owner's sex
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} apenas pode ter 1 carater, no máximo")]
        [Display(Name = "Sexo")]
        public string Sex { get; set; }

        public ICollection<Animal> Animals { get; set; } //o dono tem uma lista de animais
    }
}
