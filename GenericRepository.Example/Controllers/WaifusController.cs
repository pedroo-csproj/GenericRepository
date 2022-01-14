using GenericRepository.Example.Data.Interfaces;
using GenericRepository.Example.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GenericRepository.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaifusController : ControllerBase
    {
        public WaifusController(IWaifuRepository waifuRepository) =>
            _waifuRepository = waifuRepository;

        private readonly IWaifuRepository _waifuRepository;

        [HttpGet]
        public async Task<IActionResult> ToListAsync()
        {
            var waifus = await _waifuRepository.ToListAsync<Waifu>(default);

            return Ok(waifus);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindAsync([FromRoute] Guid id)
        {
            var waifu = await _waifuRepository.FindAsync<Waifu, Guid>(id, default);

            if (waifu == null)
                return NotFound();

            return Ok(waifu);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Waifu waifu)
        {
            await _waifuRepository.AddAsync(waifu, default);
            await _waifuRepository.SaveChangesAsync(default);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Waifu waifu)
        {
            _waifuRepository.Update(waifu);
            await _waifuRepository.SaveChangesAsync(default);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id)
        {
            var waifu = await _waifuRepository.FindAsync<Waifu, Guid>(id, default);

            if (waifu == null)
                return NotFound();

            _waifuRepository.Update(waifu);
            await _waifuRepository.SaveChangesAsync(default);

            return Ok();
        }
    }
}
