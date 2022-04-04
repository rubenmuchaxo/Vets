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
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais de {1} carateres")]
        [Display(Name = "Nome")]
        [RegularExpression("[A-ZÁÉÍÓÚÂÔa-záéíóúàèìòùãõõñâêîôûäëïöüç -']+", ErrorMessage ="Só pode escrever letras no {0}")]
        public string Name { get; set; }

        /// <summary>
        /// Owner's unique identification number
        /// </summary>
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter exatamente 9 números")]
        [Display(Name = "NIF")]
        [RegularExpression("[123578][0-9]{8}",ErrorMessage ="O {0} deve começar por 1,2,3,5,7,8 e ser seguido de 8 dígitos numéricos.")]
        public string NIF { get; set; }

        /// <summary>
        /// Owner's sex
        /// </summary>
        [StringLength(1, ErrorMessage ="O {0} apenas pode ter 1 carater, no máximo")]
        [Display(Name = "Sexo")]
        [RegularExpression("[MmFf]",ErrorMessage ="O {0} apenas pode ser Masculino (M ou m) ou Feminino (F ou f).")]
        public string Sex { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [EmailAddress(ErrorMessage ="Insira um email válido.")]
        public string email { get; set; }

        public ICollection<Animal> Animals { get; set; } //o dono tem uma lista de animais
    }
}
