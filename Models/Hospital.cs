namespace EtulasAPI.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int OccupiedBeds { get; set; }

        // Calcula a taxa de ocupação
        public double OccupationRate => (double)OccupiedBeds / Capacity * 100;
    }
}
