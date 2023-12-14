using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Buisness.Models;
using Web.Buisness.Features.UiPageType.Commands;
using AutoMapper;
using Web.Buisness.Features.UiPageType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UiPageTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UiPageTypeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/<PersonController>
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<UiPageType>> GetAll()
        {
            return await _mediator.Send(new GetUiPageType.Command());
        }

        // GET api/<PersonController>/5
        [HttpGet]
        [Route("GetById")]
        public async Task<UiPageType> GetById(int id)
        {
            return await _mediator.Send(new GetByIdUiPageType.Command(id));
        }

        // POST api/<PersonController>
        [HttpPost]
        [Route("Create")]
        public async Task<UiPageType> Create([FromBody] UiPageType uiPageType)
        {
            var model = _mapper.Map<CreateUiPageType.Command>(uiPageType);
            return await _mediator.Send(model);

            //or we can pass list of error messages using result.Errors like requestResult
            return null;
        }
        // POST api/<PersonController>
        [HttpPost]
        [Route("Update")]
        public async Task<UiPageType> Update([FromBody] UiPageType uiPageType)
        {
            var model = _mapper.Map<UpdateUiPageType.Command>(uiPageType);
            return await _mediator.Send(model);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<int> Delete(int id)
        {
            var model = new DeleteUiPageType.Command(id);
            return await _mediator.Send(model);
        }
    }
}
