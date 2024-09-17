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
                // Hospital não encontrado
                throw new KeyNotFoundException("Hospital não encontrado.");
            }

            // Atualizar os campos necessários
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
                    // Se o hospital não existe mais após a exceção
                    throw new KeyNotFoundException("Hospital não encontrado durante a atualização.");
                }
                else
                {
                    // Erro de concorrência
                    throw;
                }
            }
        }


        public async Task DeleteHospitalAsync(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            // Verifica se o hospital foi encontrado
            if (hospital == null)
            {
                return; // Retorna sem fazer nada se o hospital não for encontrado
            }

            // Recarrega os dados do hospital para garantir que a versão mais recente seja usada
            _context.Entry(hospital).Reload();

            // Tenta excluir o hospital
            try
            {
                _context.Hospitals.Remove(hospital);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Lidar com o conflito de concorrência (exibir mensagem ao usuário etc.)
                // Você pode implementar sua própria lógica de tratamento de conflito aqui
                throw new Exception("O registro do hospital foi modificado por outro usuário. A exclusão não foi realizada.");
            }
        }

        public async Task<bool> HospitalExists(int id)
        {
            return await _context.Hospitals.AnyAsync(e => e.Id == id);
        }

    }
}
