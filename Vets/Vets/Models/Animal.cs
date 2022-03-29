using System.ComponentModel.DataAnnotations.Schema;

namespace Vets.Models
{
    public class Animal
    {

        public Animal()
        {
            Appointments = new HashSet<Appointment>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Species { get; set; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public string Photo { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerFK { get; set; }
        public Owner Owner { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
