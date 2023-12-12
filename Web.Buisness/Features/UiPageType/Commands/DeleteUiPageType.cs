using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Web.Buisness.Interface;
using WebBuisness.Repository.Interface;

namespace Web.Buisness.Features.UiPageType.Commands
{
    public static class DeleteUiPageType
    {
        public record UiPageTypeDeleteCommand(int Id) : IRequest<int>;
        public class Command : IRequest<int>
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
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id Cannot be Null");
            }
        }
        public class Authorization : IAuthorizationRule<Command>
        {

            public Task Authorize(Command request, CancellationToken cancellationToken, IHttpContextAccessor contex)
            {
                throw new NotImplementedException();
            }
        }
        public class Handler : IRequestHandler<Command,int>
        {
            private readonly IUiPageTypeRepository _uiPageTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IUiPageTypeRepository uiPageTypeRepository, IMapper mapper)
            {
                _uiPageTypeRepository = uiPageTypeRepository;
                _mapper = mapper;
            }

            Task<int> IRequestHandler<Command, int>.Handle(Command request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_uiPageTypeRepository.Delete(request.Id));
            }
        }
    }
    
}
