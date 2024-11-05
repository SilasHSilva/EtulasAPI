using EtulasAPI.Data;
using EtulasAPI.Interfaces;
using EtulasAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtulasAPI.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly HospitalDbContext _context;

        public HospitalService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsAsync()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task<Hospital> GetHospitalByIdAsync(int id)
        {
            return await _context.Hospitals.FindAsync(id);
        }

        public async Task<Hospital> AddHospitalAsync(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            return hospital;
        }

        public async Task UpdateHospitalAsync(Hospital hospital)
        {
            var existingHospital = await _context.Hospitals.FindAsync(hospital.Id);
            if (existingHospital == null)
            {
                throw new KeyNotFoundException("Hospital não encontrado.");
            }
            existingHospital.Name = hospital.Name;
            existingHospital.Capacity = hospital.Capacity;
            existingHospital.OccupiedBeds = hospital.OccupiedBeds;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HospitalExists(hospital.Id))
                {
                    throw new KeyNotFoundException("Hospital não encontrado durante a atualização.");
                }
                else
                {
                    throw;
                }
            }
        }


        public async Task DeleteHospitalAsync(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital == null)
            {
                return;
            }

            _context.Entry(hospital).Reload();
            try
            {
                _context.Hospitals.Remove(hospital);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("O registro do hospital foi modificado por outro usuário. A exclusão não foi realizada.");
            }
        }

        public async Task<bool> HospitalExists(int id)
        {
            return await _context.Hospitals.AnyAsync(e => e.Id == id);
        }

    }
}
