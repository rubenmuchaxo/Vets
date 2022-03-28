namespace Vets.Models
{
    public class Owner
    {

        public Owner()
        {
            Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string NIF { get; set; }

        public string Sex { get; set; }

        public ICollection<Animal> Animals { get; set; } //o dono tem uma lista de animais
    }
}
