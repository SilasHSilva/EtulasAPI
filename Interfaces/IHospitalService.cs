using EtulasAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtulasAPI.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetHospitalsAsync();
        Task<Hospital> GetHospitalByIdAsync(int id);
        Task<Hospital> AddHospitalAsync(Hospital hospital);
        Task UpdateHospitalAsync(Hospital hospital);
        Task DeleteHospitalAsync(int id);
        Task<bool> HospitalExists(int id);
    }
}
