using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Web.Buisness.Interface;
using WebBuisness.Repository.Interface;

namespace Web.Buisness.Features.UiPageType.Commands
{
    public static class CreateUiPageType
    {
        public class Command : IRequest<Web.Buisness.Models.UiPageType>
        {
            public string Name { get; set; }
            public Command(string name)
            {
                Name = name;
            }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotNull().MinimumLength(3).WithMessage("Name Cannot be Null");
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
                var product = _mapper.Map<Models.UiPageType>(request);
                return Task.FromResult(_uiPageTypeRepository.Create(product));
            }
        }
    }
    
}
