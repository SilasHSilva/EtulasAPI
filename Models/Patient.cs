using EtulasAPI.Models;

namespace EtulasAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
