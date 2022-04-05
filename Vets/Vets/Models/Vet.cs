using System.ComponentModel.DataAnnotations;

namespace Vets.Models
{
    /// <summary>
    /// data from Vets
    /// </summary>
    public class Vet
    {
        public Vet()
        {
            Appointments = new HashSet<Appointment>();

        }
        /// <summary>
        /// PK for Vets
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Vet's name
        /// </summary>
        [Display(Name = "Nome")]
        public string Name { get; set; }

        /// <summary>
        /// Vet's professional license
        /// </summary>
        [Display(Name = "Licensa profissional")]
        public string ProfessionalLicense { get; set; }

        /// <summary>
        /// Vet's photo
        /// </summary>
        [Display(Name = "Fotografia")]
        public string Photo { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
