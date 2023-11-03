using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class DriverController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
                [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DriverDto>>> Get1()
        {
            var result = await _unitOfWork.Drivers
                                        .GetAllAsync();

            return _mapper.Map<List<DriverDto>>(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DriverDto>> Get2(int id)
        {
            var result = await _unitOfWork.Drivers.GetByIdAsync(id);
            return _mapper.Map<DriverDto>(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Driver>> Post(DriverDto resultDto)
        {
            var result = _mapper.Map<Driver>(resultDto);
            this._unitOfWork.Drivers.Add(result);
            await _unitOfWork.SaveAsync();
            if (result == null)
            {
                return BadRequest();
            }
            resultDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Driver>> Put(int id, [FromBody] DriverDto resultDto)
        {
            var result = _mapper.Map<Driver>(resultDto);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Drivers.Update(result);
            await _unitOfWork.SaveAsync();
            return result;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Drivers.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Drivers.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
