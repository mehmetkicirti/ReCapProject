using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _iRentalService;
        public RentalsController(IRentalService rentalService)
        {
            _iRentalService = rentalService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_iRentalService.GetRentals());
        }
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _iRentalService.GetRentalById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _iRentalService.GetRentalById(id);
            if (result.IsSuccess)
            {
                _iRentalService.Remove(result.Data);
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            IResult result = _iRentalService.Add(rental);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            IResult result = _iRentalService.Update(rental);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
