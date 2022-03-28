namespace Vets.Models
{
    public class Vet
    {
        public Vet()
        {
            Appointments = new HashSet<Appointment>();

        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProfessionalLicense { get; set; }

        public string Photo { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
