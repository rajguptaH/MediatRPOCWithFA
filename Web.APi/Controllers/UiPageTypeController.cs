using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Buisness.Models;
using Web.Buisness.Features.UiPageType.Commands;
using Web.Buisness.Features.UiPageType.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UiPageTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UiPageTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PersonController>
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<UiPageType>> GetAll()
        {
            return await _mediator.Send(new GetUiPageTypeQuery());
        }

        // GET api/<PersonController>/5
        [HttpGet]
        [Route("GetById")]
        public async Task<UiPageType> GetById(int id)
        {
            return await _mediator.Send(new GetUiPageTypeByIdQuery(id));
        }

        // POST api/<PersonController>
        [HttpPost]
        [Route("Create")]
        public async Task<UiPageType> Create([FromBody] UiPageType uiPageType)
        {
            
                var model = new UiPageTypeCreateCommand(uiPageType.Name);
                return await _mediator.Send(model);
            
            //or we can pass list of error messages using result.Errors like requestResult
            return null;
        }
        // POST api/<PersonController>
        [HttpPost]
        [Route("Update")]
        public async Task<UiPageType> Update([FromBody] UiPageType uiPageType)
        {
            var model = new UiPageTypeUpdateCommand(uiPageType.Id,uiPageType.Name);
            return await _mediator.Send(model);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<int> Delete(int id)
        {
            var model = new UiPageTypeDeleteCommand(id);
            return await _mediator.Send(model);
        }
    }
}
