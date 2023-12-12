using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Web.Buisness.Interface;
using WebBuisness.Repository.Interface;

namespace Web.Buisness.Features.UiPageType.Commands
{
    public static class GetByIdUiPageType
    {
        public class Command : IRequest<Web.Buisness.Models.UiPageType>
        {
            public int Id { get; set; }
            public Command(int id)
            {
                Id = id;
            }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Id).IsInEnum().WithMessage("Id Cannot be Null");
            }
        }
        public class Authorization : IAuthorizationRule<Command>
        {

            public Task Authorize(Command request, CancellationToken cancellationToken, IHttpContextAccessor contex)
            {
                throw new NotImplementedException();
            }
        }
        public class Handler : IRequestHandler<Command, Web.Buisness.Models.UiPageType>
        {
            private readonly IUiPageTypeRepository _uiPageTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IUiPageTypeRepository uiPageTypeRepository, IMapper mapper)
            {
                _uiPageTypeRepository = uiPageTypeRepository;
                _mapper = mapper;
            }

            Task<Models.UiPageType> IRequestHandler<Command, Models.UiPageType>.Handle(Command request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_uiPageTypeRepository.Get(request.Id));
            }
        }
    }
    
}
