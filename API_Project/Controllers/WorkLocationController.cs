using AutoMapper;
using HotelProject.BuninessLayer.Abstract;
using HotelProject.DTOLayer.DTOS.WorkLocation;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationServices _workLocationServices;
        private readonly IMapper _mapper;

        public WorkLocationController(IWorkLocationServices workLocationServices, IMapper mapper)
        {
            _workLocationServices = workLocationServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult WorkLocationlist()
        {
            var value = _workLocationServices.TGetList();
            return Ok(value);
        }
      
        [HttpPost]
        public IActionResult AddWorkLocation(CreateWorkLocationDto workLocation)
        {
            var value= _mapper.Map<WorkLocation>(workLocation);
            _workLocationServices.TInsert(value);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteWorkLocation(int id)
        {
            var value = _workLocationServices.TGetByID(id);
            _workLocationServices.TDelete(value);
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetWorkLocation(int id)
        {
            var values = _workLocationServices.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(UpdateWorkLocationDto updateWorkLocationDto)
        {
            var value = _mapper.Map<WorkLocation>(updateWorkLocationDto);
            _workLocationServices.TUpdate(value);
            return Ok();
        }
    }
}
