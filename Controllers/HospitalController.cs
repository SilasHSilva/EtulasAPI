using EtulasAPI.Interfaces;
using EtulasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HospitalOvercrowdingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService ?? throw new ArgumentNullException(nameof(hospitalService));
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await _hospitalService.GetHospitalsAsync();
            return Ok(hospitals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHospital(int id)
        {
            var hospital = await _hospitalService.GetHospitalByIdAsync(id);
            if (hospital == null) return NotFound();
            return Ok(hospital);
        }

        [HttpPost]
        public async Task<IActionResult> AddHospital([FromBody] Hospital hospital)
        {
            if (hospital == null)
            {
                return BadRequest("Hospital não pode ser nulo.");
            }

            var createdHospital = await _hospitalService.AddHospitalAsync(hospital);
            return CreatedAtAction(nameof(GetHospital), new { id = createdHospital.Id }, createdHospital);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHospital(int id, [FromBody] Hospital hospital)
        {
            if (hospital == null)
            {
                return BadRequest("Hospital não pode ser nulo.");
            }

            if (id != hospital.Id)
            {
                return BadRequest("O ID do hospital não corresponde.");
            }

            try
            {
                await _hospitalService.UpdateHospitalAsync(hospital);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _hospitalService.HospitalExists(id))
                {
                    return NotFound("Hospital não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            await _hospitalService.DeleteHospitalAsync(id);
            return NoContent();
        }
    }
}
