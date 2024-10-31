using AutoMapper;
using DSCC_CW1_11095_Back.Dtos;
using DSCC_CW1_11095_Back.Interfaces;
using DSCC_CW1_11095_Back.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSCC_CW1_11095_Back.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public ProducerController(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProducerDto>>> GetAllProducers()
        {
            var producers = await _producerRepository.GetAllAsync();
            var producerDtos = _mapper.Map<IEnumerable<ProducerDto>>(producers);
            return Ok(producerDtos);
        }

        [HttpGet("{id}", Name = "GetProducerById")]
        public async Task<ActionResult<ProducerDto>> GetProducerById(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            if (producer == null) return NotFound();
            return Ok(_mapper.Map<ProducerDto>(producer));
        }

        [HttpPost]
        public async Task<ActionResult<ProducerDto>> CreateProducer(ProducerCreateDto producerCreateDto)
        {
            var producer = _mapper.Map<Producer>(producerCreateDto);
            await _producerRepository.AddAsync(producer);

            var producerDto = _mapper.Map<ProducerDto>(producer);
            return CreatedAtRoute("GetProducerById", new { id = producerDto.Id }, producerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducer(int id, ProducerCreateDto producerUpdateDto)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            if (producer == null) return NotFound();

            _mapper.Map(producerUpdateDto, producer);
            await _producerRepository.UpdateAsync(producer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            if (producer == null) return NotFound();

            await _producerRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
